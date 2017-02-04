module Tests
open System
open Expecto
open Currency
open Money


type Payment = {
    Value : Money;
    Comment : string;
}
type DBRec = {
    CurrencyCode : string;
    Amount : decimal;
    Comment : string
}
let data = 
    [
        {CurrencyCode = "USD"; Amount = 5.50m; Comment = "Latte"}
        {CurrencyCode = "USD"; Amount = 6.50m; Comment = "Scone"}
        {CurrencyCode = "CAD"; Amount = 4.33m; Comment = "Americano"}
    ]

let makePymt (dbRec : DBRec) = 
    match dbRec.CurrencyCode with
    | "USD" -> {Value = Value(dbRec.Amount, USD); Comment = dbRec.Comment}
    | "CAD" -> {Value = Value(dbRec.Amount, CAD); Comment = dbRec.Comment}
    | "GBP" -> {Value = Value(dbRec.Amount, GBP); Comment = dbRec.Comment}
    | _ -> failwith "bad currency"


let pymts =
    data 
        |> List.map makePymt

let v1 = Value(33m, CAD)
let v2 = Value(10m, USD)
let errMixed = NaV MixedCurr
let errDiv0 = NaV DivBy0
let errOver = NaV Overflow

[<Tests>]
let tests =
  testList "UnitTests" [
    testList "Values" [
        testCase "mixedCur" <| fun _ -> Expect.equal  (addValues v1 v2)  errMixed ""
        testCase "div0" <| fun _ -> Expect.equal  (divideBy v1 0m)  errDiv0 ""
        testCase "overflow" <| fun _ -> Expect.equal  (multiplyBy v1 Decimal.MaxValue)  errOver ""
    ]
    testList "CodesValidation]" [
        testCase "mixedCur" <| fun _ -> Expect.equal  (addValues v1 v2)  errMixed ""
        testCase "div0" <| fun _ -> Expect.equal  (divideBy v1 0m)  errDiv0 ""
        testCase "overflow" <| fun _ -> Expect.equal  (multiplyBy v1 Decimal.MaxValue)  errOver ""
    ]

  ]