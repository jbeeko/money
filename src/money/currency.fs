module Currency 
open System
open FSharp.Reflection

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

type CurError =
    | MixedCur
    | DivBy0
    | Overflow

type Currency =
    | AED of Decimal | AFN of Decimal | ALL of Decimal | AMD of Decimal | ANG of Decimal | AOA of Decimal 
    | ARS of Decimal | AUD of Decimal | AWG of Decimal | AZN of Decimal 
    | BAM of Decimal | BBD of Decimal | BDT of Decimal | BGN of Decimal | BHD of Decimal | BIF of Decimal 
    | BMD of Decimal | BND of Decimal | BOB of Decimal | BOV of Decimal | BRL of Decimal | BSD of Decimal 
    | BTN of Decimal | BWP of Decimal | BYN of Decimal | BZD of Decimal 
    | CAD of Decimal | CDF of Decimal | CHE of Decimal | CHF of Decimal | CHW of Decimal | CLF of Decimal 
    | CLP of Decimal | CNY of Decimal | COP of Decimal | COU of Decimal | CRC of Decimal | CUC of Decimal 
    | CUP of Decimal | CVE of Decimal | CZK of Decimal 
    | DJF of Decimal | DKK of Decimal | DOP of Decimal | DZD of Decimal 
    | EGP of Decimal | ERN of Decimal | ETB of Decimal | EUR of Decimal 
    | FJD of Decimal | FKP of Decimal 
    | GBP of Decimal | GEL of Decimal | GHS of Decimal | GIP of Decimal | GMD of Decimal | GNF of Decimal 
    | GTQ of Decimal | GYD of Decimal 
    | HKD of Decimal | HNL of Decimal | HRK of Decimal | HTG of Decimal | HUF of Decimal 
    | IDR of Decimal | ILS of Decimal | INR of Decimal | IQD of Decimal | IRR of Decimal | ISK of Decimal 
    | JMD of Decimal | JOD of Decimal 
    | JPY of Decimal | KES of Decimal | KGS of Decimal | KHR of Decimal | KMF of Decimal | KPW of Decimal 
    | KRW of Decimal | KWD of Decimal | KYD of Decimal | KZT of Decimal 
    | LAK of Decimal | LBP of Decimal | LKR of Decimal | LRD of Decimal | LSL of Decimal | LYD of Decimal 
    | MAD of Decimal | MDL of Decimal | MGA of Decimal | MKD of Decimal | MMK of Decimal | MNT of Decimal 
    | MOP of Decimal | MRO of Decimal | MUR of Decimal | MVR of Decimal | MWK of Decimal | MXN of Decimal 
    | MXV of Decimal | MYR of Decimal | MZN of Decimal 
    | NAD of Decimal | NGN of Decimal | NIO of Decimal | NOK of Decimal | NPR of Decimal | NZD of Decimal 
    | OMR of Decimal 
    | PAB of Decimal | PEN of Decimal | PGK of Decimal | PHP of Decimal | PKR of Decimal | PLN of Decimal 
    | PYG of Decimal 
    | QAR of Decimal 
    | RON of Decimal | RSD of Decimal | RUB of Decimal | RWF of Decimal 
    | SAR of Decimal | SBD of Decimal | SCR of Decimal | SDG of Decimal | SEK of Decimal | SGD of Decimal 
    | SHP of Decimal | SLL of Decimal | SOS of Decimal | SRD of Decimal | SSP of Decimal | STD of Decimal 
    | SVC of Decimal | SYP of Decimal | SZL of Decimal 
    | THB of Decimal | TJS of Decimal | TMT of Decimal | TND of Decimal | TOP of Decimal | TRY of Decimal 
    | TTD of Decimal | TWD of Decimal | TZS of Decimal 
    | UAH of Decimal | UGX of Decimal | USD of Decimal | UYI of Decimal | UYU of Decimal | UZS of Decimal 
    | VEF of Decimal | VND of Decimal | VUV of Decimal 
    | WST of Decimal 
    | XAF of Decimal | XCD of Decimal | XOF of Decimal | XPF of Decimal 
    | YER of Decimal 
    | ZAR of Decimal | ZMW of Decimal | ZWL of Decimal
    // testing and null currency
    | XTS of Decimal 
    | XXX of Decimal
    // error and identity values
    | NaV of CurError
    | Zero

let negate value =
    let c, f = FSharpValue.GetUnionFields(value, value.GetType())
    match value with
    | Zero -> Zero
    | NaV err -> NaV err
    | _ -> 
        let amt = unbox (f.[0])
        if amt = 0m
        then value
        else unbox (FSharpValue.MakeUnion(c, [|box amt|])) 

let addValues v1 v2 =
    let c1, f1 = FSharpValue.GetUnionFields(v1, v1.GetType())
    let c2, f2 = FSharpValue.GetUnionFields(v2, v2.GetType())

    match (v1, v2) with
    | (NaV err, _) | (_, NaV err) -> NaV err
    | (Zero, _) -> v2
    | (_, Zero) ->v1
    | (_, _) when c1 = c2 ->
        let amt1 = (f1.[0]) :?> decimal
        let amt2 = (f2.[0]) :?> decimal
        try 
            let tmp = amt1 + amt2
            if inRange tmp 
            then unbox (FSharpValue.MakeUnion(c1, [|box tmp|]))
            else NaV Overflow
        with 
            | :? OverflowException as ex -> NaV Overflow
    | _ -> NaV MixedCur

let subtractValues v1 v2 =
    addValues v1 (negate v2)

let (.+.) = addValues

let multiplyBy value factor =
    let c, f = FSharpValue.GetUnionFields(value, value.GetType())
    match value with
    | NaV err -> value
    | Zero -> value
    | _ -> 
        try 
            let amt = unbox (f.[0])
            let tmp = amt*factor
            if inRange tmp
            then unbox (FSharpValue.MakeUnion(c, [|box tmp|]))
            else NaV Overflow
        with 
            | :? OverflowException as ex -> NaV Overflow

let divideBy value divisor  =
    if divisor = 0m
    then NaV DivBy0
    else multiplyBy value (1m/divisor)

let (.*.) = multiplyBy

[<StructuredFormatDisplay("{Currency}")>]
type CurrencyDetails = {
    Currency : Currency;
    Number : int 
    Name : string
    Decimals : int
}

let Currencies = 
    [
    {Currency = AED 0m; Number = 784; Name = "UAE Dirham"; Decimals = 2};
    {Currency = AFN 0m; Number = 971; Name = "Afghani"; Decimals = 2};
    {Currency = ALL 0m; Number = 008; Name = "Lek"; Decimals = 2};
    {Currency = AMD 0m; Number = 051; Name = "Armenian Dram"; Decimals = 2};
    {Currency = ANG 0m; Number = 532; Name = "Netherlands Antillean Guilder"; Decimals = 2};
    {Currency = AOA 0m; Number = 973; Name = "Kwanza"; Decimals = 2};
    {Currency = ARS 0m; Number = 032; Name = "Argentine Peso"; Decimals = 2};
    {Currency = AUD 0m; Number = 036; Name = "Australian Dollar"; Decimals = 2};
    {Currency = AWG 0m; Number = 533; Name = "Aruban Florin"; Decimals = 2};
    {Currency = AZN 0m; Number = 944; Name = "Azerbaijanian Manat"; Decimals = 2};
    {Currency = BAM 0m; Number = 977; Name = "Convertible Mark"; Decimals = 2};
    {Currency = BBD 0m; Number = 052; Name = "Barbados Dollar"; Decimals = 2};
    {Currency = BDT 0m; Number = 050; Name = "Taka"; Decimals = 2};
    {Currency = BGN 0m; Number = 975; Name = "Bulgarian Lev"; Decimals = 2};
    {Currency = BHD 0m; Number = 048; Name = "Bahraini Dinar"; Decimals = 3};
    {Currency = BIF 0m; Number = 108; Name = "Burundi Franc"; Decimals = 0};
    {Currency = BMD 0m; Number = 060; Name = "Bermudian Dollar"; Decimals = 2};
    {Currency = BND 0m; Number = 096; Name = "Brunei Dollar"; Decimals = 2};
    {Currency = BOB 0m; Number = 068; Name = "Boliviano"; Decimals = 2};
    {Currency = BOV 0m; Number = 984; Name = "Mvdol"; Decimals = 2};
    {Currency = BRL 0m; Number = 986; Name = "Brazilian Real"; Decimals = 2};
    {Currency = BSD 0m; Number = 044; Name = "Bahamian Dollar"; Decimals = 2};
    {Currency = BTN 0m; Number = 064; Name = "Ngultrum"; Decimals = 2};
    {Currency = BWP 0m; Number = 072; Name = "Pula"; Decimals = 2};
    {Currency = BYN 0m; Number = 933; Name = "Belarusian Ruble"; Decimals = 2};
    {Currency = BZD 0m; Number = 084; Name = "Belize Dollar"; Decimals = 2};
    {Currency = CAD 0m; Number = 124; Name = "Canadian Dollar"; Decimals = 2};
    {Currency = CDF 0m; Number = 976; Name = "Congolese Franc"; Decimals = 2};
    {Currency = CHE 0m; Number = 947; Name = "WIR Euro"; Decimals = 2};
    {Currency = CHF 0m; Number = 756; Name = "Swiss Franc"; Decimals = 2};
    {Currency = CHW 0m; Number = 948; Name = "WIR Franc"; Decimals = 2};
    {Currency = CLF 0m; Number = 990; Name = "Unidad de Fomento"; Decimals = 4};
    {Currency = CLP 0m; Number = 152; Name = "Chilean Peso"; Decimals = 0};
    {Currency = CNY 0m; Number = 156; Name = "Yuan Renminbi"; Decimals = 2};
    {Currency = COP 0m; Number = 170; Name = "Colombian Peso"; Decimals = 2};
    {Currency = COU 0m; Number = 970; Name = "Unidad de Valor Real"; Decimals = 2};
    {Currency = CRC 0m; Number = 188; Name = "Costa Rican Colon"; Decimals = 2};
    {Currency = CUC 0m; Number = 931; Name = "Peso Convertible"; Decimals = 2};
    {Currency = CUP 0m; Number = 192; Name = "Cuban Peso"; Decimals = 2};
    {Currency = CVE 0m; Number = 132; Name = "Cabo Verde Escudo"; Decimals = 2};
    {Currency = CZK 0m; Number = 203; Name = "Czech Koruna"; Decimals = 2};
    {Currency = DJF 0m; Number = 262; Name = "Djibouti Franc"; Decimals = 0};
    {Currency = DKK 0m; Number = 208; Name = "Danish Krone"; Decimals = 2};
    {Currency = DOP 0m; Number = 214; Name = "Dominican Peso"; Decimals = 2};
    {Currency = DZD 0m; Number = 012; Name = "Algerian Dinar"; Decimals = 2};
    {Currency = EGP 0m; Number = 818; Name = "Egyptian Pound"; Decimals = 2};
    {Currency = ERN 0m; Number = 232; Name = "Nakfa"; Decimals = 2};
    {Currency = ETB 0m; Number = 230; Name = "Ethiopian Birr"; Decimals = 2};
    {Currency = EUR 0m; Number = 978; Name = "Euro"; Decimals = 2};
    {Currency = FJD 0m; Number = 242; Name = "Fiji Dollar"; Decimals = 2};
    {Currency = FKP 0m; Number = 238; Name = "Falkland Islands Pound"; Decimals = 2};
    {Currency = GBP 0m; Number = 826; Name = "Pound Sterling"; Decimals = 2};
    {Currency = GEL 0m; Number = 981; Name = "Lari"; Decimals = 2};
    {Currency = GHS 0m; Number = 936; Name = "Ghana Cedi"; Decimals = 2};
    {Currency = GIP 0m; Number = 292; Name = "Gibraltar Pound"; Decimals = 2};
    {Currency = GMD 0m; Number = 270; Name = "Dalasi"; Decimals = 2};
    {Currency = GNF 0m; Number = 324; Name = "Guinea Franc"; Decimals = 0};
    {Currency = GTQ 0m; Number = 320; Name = "Quetzal"; Decimals = 2};
    {Currency = GYD 0m; Number = 328; Name = "Guyana Dollar"; Decimals = 2};
    {Currency = HKD 0m; Number = 344; Name = "Hong Kong Dollar"; Decimals = 2};
    {Currency = HNL 0m; Number = 340; Name = "Lempira"; Decimals = 2};
    {Currency = HRK 0m; Number = 191; Name = "Kuna"; Decimals = 2};
    {Currency = HTG 0m; Number = 332; Name = "Gourde"; Decimals = 2};
    {Currency = HUF 0m; Number = 348; Name = "Forint"; Decimals = 2};
    {Currency = IDR 0m; Number = 360; Name = "Rupiah"; Decimals = 2};
    {Currency = ILS 0m; Number = 376; Name = "New Israeli Sheqel"; Decimals = 2};
    {Currency = INR 0m; Number = 356; Name = "Indian Rupee"; Decimals = 2};
    {Currency = IQD 0m; Number = 368; Name = "Iraqi Dinar"; Decimals = 3};
    {Currency = IRR 0m; Number = 364; Name = "Iranian Rial"; Decimals = 2};
    {Currency = ISK 0m; Number = 352; Name = "Iceland Krona"; Decimals = 0};
    {Currency = JMD 0m; Number = 388; Name = "Jamaican Dollar"; Decimals = 2};
    {Currency = JOD 0m; Number = 400; Name = "Jordanian Dinar"; Decimals = 3};
    {Currency = JPY 0m; Number = 392; Name = "Yen"; Decimals = 0};
    {Currency = KES 0m; Number = 404; Name = "Kenyan Shilling"; Decimals = 2};
    {Currency = KGS 0m; Number = 417; Name = "Som"; Decimals = 2};
    {Currency = KHR 0m; Number = 116; Name = "Riel"; Decimals = 2};
    {Currency = KMF 0m; Number = 174; Name = "Comoro Franc"; Decimals = 0};
    {Currency = KPW 0m; Number = 408; Name = "North Korean Won"; Decimals = 2};
    {Currency = KRW 0m; Number = 410; Name = "Won"; Decimals = 0};
    {Currency = KWD 0m; Number = 414; Name = "Kuwaiti Dinar"; Decimals = 3};
    {Currency = KYD 0m; Number = 136; Name = "Cayman Islands Dollar"; Decimals = 2};
    {Currency = KZT 0m; Number = 398; Name = "Tenge"; Decimals = 2};
    {Currency = LAK 0m; Number = 418; Name = "Kip"; Decimals = 2};
    {Currency = LBP 0m; Number = 422; Name = "Lebanese Pound"; Decimals = 2};
    {Currency = LKR 0m; Number = 144; Name = "Sri Lanka Rupee"; Decimals = 2};
    {Currency = LRD 0m; Number = 430; Name = "Liberian Dollar"; Decimals = 2};
    {Currency = LSL 0m; Number = 426; Name = "Loti"; Decimals = 2};
    {Currency = LYD 0m; Number = 434; Name = "Libyan Dinar"; Decimals = 3};
    {Currency = MAD 0m; Number = 504; Name = "Moroccan Dirham"; Decimals = 2};
    {Currency = MDL 0m; Number = 498; Name = "Moldovan Leu"; Decimals = 2};
    {Currency = MGA 0m; Number = 969; Name = "Malagasy Ariary"; Decimals = 2};
    {Currency = MKD 0m; Number = 807; Name = "Denar"; Decimals = 2};
    {Currency = MMK 0m; Number = 104; Name = "Kyat"; Decimals = 2};
    {Currency = MNT 0m; Number = 496; Name = "Tugrik"; Decimals = 2};
    {Currency = MOP 0m; Number = 446; Name = "Pataca"; Decimals = 2};
    {Currency = MRO 0m; Number = 478; Name = "Ouguiya"; Decimals = 2};
    {Currency = MUR 0m; Number = 480; Name = "Mauritius Rupee"; Decimals = 2};
    {Currency = MVR 0m; Number = 462; Name = "Rufiyaa"; Decimals = 2};
    {Currency = MWK 0m; Number = 454; Name = "Malawi Kwacha"; Decimals = 2};
    {Currency = MXN 0m; Number = 484; Name = "Mexican Peso"; Decimals = 2};
    {Currency = MYR 0m; Number = 458; Name = "Malaysian Ringgit"; Decimals = 2};
    {Currency = MZN 0m; Number = 943; Name = "Mozambique Metical"; Decimals = 2};
    {Currency = NAD 0m; Number = 516; Name = "Namibia Dollar"; Decimals = 2};
    {Currency = NGN 0m; Number = 566; Name = "Naira"; Decimals = 2};
    {Currency = NIO 0m; Number = 558; Name = "Cordoba Oro"; Decimals = 2};
    {Currency = NOK 0m; Number = 578; Name = "Norwegian Krone"; Decimals = 2};
    {Currency = NPR 0m; Number = 524; Name = "Nepalese Rupee"; Decimals = 2};
    {Currency = NZD 0m; Number = 554; Name = "New Zealand Dollar"; Decimals = 2};
    {Currency = OMR 0m; Number = 512; Name = "Rial Omani"; Decimals = 3};
    {Currency = PAB 0m; Number = 590; Name = "Balboa"; Decimals = 2};
    {Currency = PEN 0m; Number = 604; Name = "Sol"; Decimals = 2};
    {Currency = PGK 0m; Number = 598; Name = "Kina"; Decimals = 2};
    {Currency = PHP 0m; Number = 608; Name = "Philippine Peso"; Decimals = 2};
    {Currency = PKR 0m; Number = 586; Name = "Pakistan Rupee"; Decimals = 2};
    {Currency = PLN 0m; Number = 985; Name = "Zloty"; Decimals = 2};
    {Currency = PYG 0m; Number = 600; Name = "Guarani"; Decimals = 0};
    {Currency = QAR 0m; Number = 634; Name = "Qatari Rial"; Decimals = 2};
    {Currency = RON 0m; Number = 946; Name = "Romanian Leu"; Decimals = 2};
    {Currency = RSD 0m; Number = 941; Name = "Serbian Dinar"; Decimals = 2};
    {Currency = RUB 0m; Number = 643; Name = "Russian Ruble"; Decimals = 2};
    {Currency = RWF 0m; Number = 646; Name = "Rwanda Franc"; Decimals = 0};
    {Currency = SAR 0m; Number = 682; Name = "Saudi Riyal"; Decimals = 2};
    {Currency = SBD 0m; Number = 090; Name = "Solomon Islands Dollar"; Decimals = 2};
    {Currency = SCR 0m; Number = 690; Name = "Seychelles Rupee"; Decimals = 2};
    {Currency = SDG 0m; Number = 938; Name = "Sudanese Pound"; Decimals = 2};
    {Currency = SEK 0m; Number = 752; Name = "Swedish Krona"; Decimals = 2};
    {Currency = SGD 0m; Number = 702; Name = "Singapore Dollar"; Decimals = 2};
    {Currency = SHP 0m; Number = 654; Name = "Saint Helena Pound"; Decimals = 2};
    {Currency = SLL 0m; Number = 694; Name = "Leone"; Decimals = 2};
    {Currency = SOS 0m; Number = 706; Name = "Somali Shilling"; Decimals = 2};
    {Currency = SRD 0m; Number = 968; Name = "Surinam Dollar"; Decimals = 2};
    {Currency = SSP 0m; Number = 728; Name = "South Sudanese Pound"; Decimals = 2};
    {Currency = STD 0m; Number = 678; Name = "Dobra"; Decimals = 2};
    {Currency = SVC 0m; Number = 222; Name = "El Salvador Colon"; Decimals = 2};
    {Currency = SYP 0m; Number = 760; Name = "Syrian Pound"; Decimals = 2};
    {Currency = SZL 0m; Number = 748; Name = "Lilangeni"; Decimals = 2};
    {Currency = THB 0m; Number = 764; Name = "Baht"; Decimals = 2};
    {Currency = TJS 0m; Number = 972; Name = "Somoni"; Decimals = 2};
    {Currency = TMT 0m; Number = 934; Name = "Turkmenistan New Manat"; Decimals = 2};
    {Currency = TND 0m; Number = 788; Name = "Tunisian Dinar"; Decimals = 3};
    {Currency = TOP 0m; Number = 776; Name = "Pa’anga"; Decimals = 2};
    {Currency = TRY 0m; Number = 949; Name = "Turkish Lira"; Decimals = 2};
    {Currency = TTD 0m; Number = 780; Name = "Trinidad and Tobago Dollar"; Decimals = 2};
    {Currency = TWD 0m; Number = 901; Name = "New Taiwan Dollar"; Decimals = 2};
    {Currency = TZS 0m; Number = 834; Name = "Tanzanian Shilling"; Decimals = 2};
    {Currency = UAH 0m; Number = 980; Name = "Hryvnia"; Decimals = 2};
    {Currency = UGX 0m; Number = 800; Name = "Uganda Shilling"; Decimals = 0};
    {Currency = USD 0m; Number = 840; Name = "US Dollar"; Decimals = 2};
    {Currency = UYU 0m; Number = 858; Name = "Peso Uruguayo"; Decimals = 2};
    {Currency = UZS 0m; Number = 860; Name = "Uzbekistan Sum"; Decimals = 2};
    {Currency = VEF 0m; Number = 937; Name = "Bolívar"; Decimals = 2};
    {Currency = VND 0m; Number = 704; Name = "Dong"; Decimals = 0};
    {Currency = VUV 0m; Number = 548; Name = "Vatu"; Decimals = 0};
    {Currency = WST 0m; Number = 882; Name = "Tala"; Decimals = 2};
    {Currency = XAF 0m; Number = 950; Name = "CFA Franc BEAC"; Decimals = 0};
    {Currency = XCD 0m; Number = 951; Name = "East Caribbean Dollar"; Decimals = 2};
    {Currency = XOF 0m; Number = 952; Name = "CFA Franc BCEAO"; Decimals = 0};
    {Currency = XPF 0m; Number = 953; Name = "CFP Franc"; Decimals = 0};
    {Currency = XTS 0m; Number = 963; Name = "Testing"; Decimals = 2};
    {Currency = XXX 0m; Number = 999; Name = "No Currency Specified"; Decimals = 2};
    {Currency = YER 0m; Number = 886; Name = "Yemeni Rial"; Decimals = 2};
    {Currency = ZAR 0m; Number = 710; Name = "Rand"; Decimals = 2};
    {Currency = ZMW 0m; Number = 967; Name = "Zambian Kwacha"; Decimals = 2};
    {Currency = ZWL 0m; Number = 932; Name = "Zimbabwe Dollar"; Decimals = 2}] 
        |> List.map (fun r -> (r.Currency,r) )
        |> Map.ofList

let currencyRec v =
    Currencies.Item v
