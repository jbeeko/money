module Exchange
open System
open Currency

type ExchangeRate = {
    From : Currency;
    To : Currency;
    Spot : Decimal;
}

let exchange rate value

