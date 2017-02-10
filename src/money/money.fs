module Money
open System
open Currency

//Not full decimal range to ensure there will always be at least 6 significant figures.
//Also needs to fit within SQL constraint of 38 digits decimal(32, 16) which allows for 16
//places to right of decimal and 32-16 = 16 to left. 
//
//  |                        |
//  500000000000000.000000000100000
//  .net  15             15
//  NNNNNNNNNNNNNNN.DDDDDDDDDXDDDDD
//  SQL   16             16
// NNNNNNNNNNNNNNNN.DDDDDDDDDDDDDDDD

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
| Zero
| NaV of NaVError
    override this.ToString() =
        match this with
        | Value (amt, cur) ->
            let formatStr = 
                if amt = Decimal.Round(amt, cur.Decimals)
                then sprintf "%%A %%.%df" cur.Decimals
                else  "%A %M"
            let twFormat = Printf.StringFormat<Currency->decimal->string>(formatStr)
            sprintf twFormat cur amt
        | Zero -> "XXX 0.00"
        | NaV err -> sprintf "NaV %A" err
    member this.AsString = 
        this.ToString() 

let negate m =
    match m with
    | Value (amt, cur) -> 
        if amt = 0m
        then m
        else Value(Decimal.Negate(amt), cur)
    | Zero -> m
    | NaV err -> m

let addValues m1 m2 = 
    match (m1, m2) with
    | (NaV err, _) | (_, NaV err) -> NaV err
    | (Zero, _) -> m2
    | (_, Zero) -> m1
    | (Value(amt1, cur1), Value(amt2, cur2)) when cur1 = cur2 ->
        try 
            let tmp = amt1 + amt2
            if inRange tmp 
            then Value (tmp, cur1)
            else NaV Overflow
        with 
            | :? OverflowException as ex -> NaV Overflow
    | _ -> NaV MixedCurr

let subtractValues v1 v2 =
    addValues v1 (negate v2)

let (.+.) = addValues

let multiplyBy m factor =
    match m with
    | Value (amt, cur) -> 
        try 
            let tmp = amt*factor
            if inRange tmp
            then Value (tmp, cur)
            else NaV Overflow
        with 
            | :? OverflowException as ex -> NaV Overflow
    | _ -> m

let divideBy m divisor = 
    if divisor = 0m
    then NaV DivBy0
    else multiplyBy m (1m/divisor)

let (.*.) = multiplyBy

