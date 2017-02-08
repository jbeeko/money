open System
open FSharp.Reflection

type Value =
    | Tag1 of decimal
    | Tag2 of decimal
    | Tag3 of decimal
    | Error of string

let addValues v1 v2 =
    let c1, f1 = FSharpValue.GetUnionFields(v1, v1.GetType())
    let c2, f2 = FSharpValue.GetUnionFields(v2, v2.GetType())
    let amt1 = (f1.[0]) :?> decimal
    let amt2 = (f2.[0]) :?> decimal

    if c1 = c2
        then ((FSharpValue.MakeUnion(c1, [|box (amt1 + amt2)|]))) :?> Value
        else Error "Mixed Tags"

addValues (Tag1 22m) (Tag1 10m) //Value = Tag1 32M
addValues (Tag1 22m) (Tag2 10m) //Value = Error "Mixed Tags"
