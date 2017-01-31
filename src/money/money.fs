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
let CAD = {Code = CAD; Number = 444; Name = "Canadian Dollar"; Decimals = 2; MajorUnit = "Dollar"; MinorUnit = "cent"}
let USD = {Code = USD; Number = 444; Name = "US Dollar"; Decimals = 2; MajorUnit = "Dollar"; MinorUnit = "cent"}
let GBP = {Code = GBP; Number = 444; Name = "Pound Stirling"; Decimals = 2; MajorUnit = "Pound"; MinorUnit = "pence"}

[<StructuredFormatDisplay("{AsString}")>]
type Money =
| Value of Decimal*Currency
| NaV of NaVError
    with
        static member Parse(str) =
            Value(33m, CAD)
        override self.ToString() =
            match self with
            | Value (amt, cur) ->
                let formatStr = 
                    if amt = Decimal.Round(amt, cur.Decimals)
                    then sprintf "%%.%df %%A" cur.Decimals
                    else  "%M %A"
                let twFormat = Printf.StringFormat<decimal->CurrencyCode->string>(formatStr)
                sprintf twFormat amt cur.Code
            | NaV err -> sprintf "NaV %A" err
        member self.AsString = 
            self.ToString() 


let addValues v1 v2 = 
    match (v1, v2) with
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
        try Value (amt*factor, cur)
        with 
            | :? OverflowException as ex -> NaV Overflow
    | NaV err -> NaV err

let devideBy money divisor  =
    match money with
    | Value (amt, cur) -> 
        if divisor  = 0m
        then NaV DivBy0
        else 
            try Value (amt/divisor , cur)
            with 
                | :? OverflowException as ex -> NaV Overflow
    | NaV err -> NaV err

let (.*.) = multiplyBy

let negate money =
    match money with
    | Value (amt, cur) -> 
        if amt = 0m
        then money
        else Value(Decimal.Negate(amt), cur)
    | NaV err -> NaV err


// open Currencies

// type Payment = {
//     Value : Money;
//     Comment : String;
// }
// type DBRec = {
//     CurrencyCode : String;
//     Amount : decimal;
//     Comment : String
// }
// let data = 
//     [
//         {CurrencyCode = "USD"; Amount = 5.50m; Comment = "Latte"}
//         {CurrencyCode = "USD"; Amount = 6.50m; Comment = "Scone"}
//         {CurrencyCode = "CAD"; Amount = 4.33m; Comment = "Americano"}
//     ]

// let makePymt (dbRec : DBRec) = 
//     match dbRec.CurrencyCode with
//     | "USD" -> {Value = Value(dbRec.Amount, USD); Comment = dbRec.Comment}
//     | "CAD" -> {Value = Value(dbRec.Amount, CAD); Comment = dbRec.Comment}
//     | "GBP" -> {Value = Value(dbRec.Amount, GBP); Comment = dbRec.Comment}
//     | _ -> failwith "bad currency"


// let pymts =
//     data 
//         |> List.map makePymt

// pymts
//     |> List.map (fun p -> p.Value)
//     |> List.reduce addValues


// CAD

