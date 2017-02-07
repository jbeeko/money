module Money
open System
open Currency

//Not full decimal range to ensure there will always be at least 6 significant figures.
//Also needs to fit within SQL constraint of 38 digits decimal(32, 16) which allows for 16
//places to right of decimal and 32-16 = 16 to left. 
//  500000000000000.000000000100000
//          15             15
//  NNNNNNNNNNNNNNN.DDDDDDDDDDDDDDD
let (><) x (min, max) =
    (x > min) && (x < max)

let ValueRange = (0.000000000100000m, 500000000000000m)
let inRange amt =
    abs amt = 0m || (abs amt >< ValueRange)

type NaVError =
    | MixedCurr
    | DivBy0
    | Overflow
    
[<StructuredFormatDisplay("{AsString}")>]
type Money =
| Value of Decimal*Currency
| NaV of NaVError
    with
        override this.ToString() =
            match this with
            | Value (amt, cur) ->
                let formatStr = 
                    if amt = Decimal.Round(amt, (currencyRec cur).Decimals)
                    then sprintf "%%A %%.%df" (currencyRec cur).Decimals
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
        try 
            let tmp = amt1 + amt2
            if inRange tmp 
            then Value (tmp, cur1)
            else NaV Overflow
        with 
            | :? OverflowException as ex -> NaV Overflow
    | _ -> NaV MixedCurr

let (.+.) = addValues

let multiplyBy money factor =
    match money with
    | Value (amt, cur) -> 
        try 
            let tmp = amt*factor
            if inRange tmp
            then Value (tmp, cur)
            else NaV Overflow
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
                let tmp = amt/divisor
                if inRange tmp
                then Value (tmp , cur) 
                else NaV Overflow
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
