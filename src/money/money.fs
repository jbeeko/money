module Money 
open System

type CurrencyCode =
    | CAD
    | USD
    | GBP
type NaVError =
    | MixedCurr
    | DivBy0
    | Overflow

[<StructuredFormatDisplay("{Code}")>]
type Currency = {
    Code : CurrencyCode;
    Number : int 
    Name : string
    Decimals : int
    MajorUnit : string
    MinorUnit : string
}

let maxValue = Decimal.MaxValue/1000000000001m
let CAD = {Code = CAD; Number = 444; Name = "Canadian Dollar"; Decimals = 2; MajorUnit = "Dollar"; MinorUnit = "cent"}
let USD = {Code = USD; Number = 444; Name = "US Dollar"; Decimals = 2; MajorUnit = "Dollar"; MinorUnit = "cent"}
let GBP = {Code = GBP; Number = 444; Name = "Pound Stirling"; Decimals = 2; MajorUnit = "Pound"; MinorUnit = "pence"}

[<StructuredFormatDisplay("{AsString}")>]
type Money =
| Value of Decimal*Currency
| NaV of NaVError
    with
        override this.ToString() =
            match this with
            | Value (amt, cur) ->
                let formatStr = 
                    if amt = Decimal.Round(amt, cur.Decimals)
                    then sprintf "%%A %%.%df" cur.Decimals
                    else  "%A %M"
                let twFormat = Printf.StringFormat<Currency->decimal->string>(formatStr)
                sprintf twFormat cur amt
            | NaV err -> sprintf "NaV %A" err
        member this.AsString = 
            this.ToString() 

let addValues m1 m2 = 
    match (m1, m2) with
    | (NaV err, _) | (_, NaV err) -> NaV err
    | (Value(amt1, cur1), Value(amt2, cur2)) when cur1 = cur2 ->
        try Value (amt1 + amt2, cur1)
        with 
            | :? OverflowException as ex -> NaV Overflow
    | _ -> NaV MixedCurr

let (.+.) = addValues

let multiplyBy money factor =
    match money with
    | Value (amt, cur) -> 
        try 
            let tmp = amt*factor
            if tmp > maxValue
            then NaV Overflow
            else Value (tmp, cur)
        with 
            | :? OverflowException as ex -> NaV Overflow
    | NaV err -> money

let divideBy money divisor  =
    match money with
    | Value (amt, cur) -> 
        if divisor  = 0m
        then NaV DivBy0
        else 
            try 
                Value (amt/divisor , cur) 
            with 
                | :? OverflowException as ex -> NaV Overflow
    | NaV err -> money

let (.*.) = multiplyBy

let negate money =
    match money with
    | Value (amt, cur) -> 
        if amt = 0m
        then money
        else Value(Decimal.Negate(amt), cur)
    | NaV err -> NaV err
