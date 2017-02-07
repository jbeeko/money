module Currency 
open System
open Country

type Currency =
    | AED | AFN | ALL | AMD | ANG | AOA | ARS | AUD | AWG | AZN 
    | BAM | BBD | BDT | BGN | BHD | BIF | BMD | BND | BOB | BOV | BRL | BSD | BTN | BWP | BYN | BZD 
    | CAD | CDF | CHE | CHF | CHW | CLF | CLP | CNY | COP | COU | CRC | CUC | CUP | CVE | CZK 
    | DJF | DKK | DOP | DZD 
    | EGP | ERN | ETB | EUR 
    | FJD | FKP 
    | GBP | GEL | GHS | GIP | GMD | GNF | GTQ | GYD 
    | HKD | HNL | HRK | HTG | HUF 
    | IDR | ILS | INR | IQD | IRR | ISK 
    | JMD | JOD | JPY 
    | KES | KGS | KHR | KMF | KPW | KRW | KWD | KYD | KZT 
    | LAK | LBP | LKR | LRD | LSL | LYD 
    | MAD | MDL | MGA | MKD | MMK | MNT | MOP | MRO | MUR | MVR | MWK | MXN | MXV | MYR | MZN 
    | NAD | NGN | NIO | NOK | NPR | NZD 
    | OMR 
    | PAB | PEN | PGK | PHP | PKR | PLN | PYG 
    | QAR 
    | RON | RSD | RUB | RWF 
    | SAR | SBD | SCR | SDG | SEK | SGD | SHP | SLL | SOS | SRD | SSP | STD | SVC | SYP | SZL 
    | THB | TJS | TMT | TND | TOP | TRY | TTD | TWD | TZS 
    | UAH | UGX | USD | UYI | UYU | UZS 
    | VEF | VND | VUV 
    | WST 
    | XAF | XCD | XOF | XPF | XTS | XXX
    | YER 
    | ZAR | ZMW | ZWL
   

[<StructuredFormatDisplay("{Currency}")>]
type CurrencyDetails = {
    Currency : Currency;
    Number : int 
    Name : string
    Decimals : int
}

let Currencies = 
    [
    {Currency = AED; Number = 784; Name = "UAE Dirham"; Decimals = 2};
    {Currency = AFN; Number = 971; Name = "Afghani"; Decimals = 2};
    {Currency = ALL; Number = 008; Name = "Lek"; Decimals = 2};
    {Currency = AMD; Number = 051; Name = "Armenian Dram"; Decimals = 2};
    {Currency = ANG; Number = 532; Name = "Netherlands Antillean Guilder"; Decimals = 2};
    {Currency = AOA; Number = 973; Name = "Kwanza"; Decimals = 2};
    {Currency = ARS; Number = 032; Name = "Argentine Peso"; Decimals = 2};
    {Currency = AUD; Number = 036; Name = "Australian Dollar"; Decimals = 2};
    {Currency = AWG; Number = 533; Name = "Aruban Florin"; Decimals = 2};
    {Currency = AZN; Number = 944; Name = "Azerbaijanian Manat"; Decimals = 2};
    {Currency = BAM; Number = 977; Name = "Convertible Mark"; Decimals = 2};
    {Currency = BBD; Number = 052; Name = "Barbados Dollar"; Decimals = 2};
    {Currency = BDT; Number = 050; Name = "Taka"; Decimals = 2};
    {Currency = BGN; Number = 975; Name = "Bulgarian Lev"; Decimals = 2};
    {Currency = BHD; Number = 048; Name = "Bahraini Dinar"; Decimals = 3};
    {Currency = BIF; Number = 108; Name = "Burundi Franc"; Decimals = 0};
    {Currency = BMD; Number = 060; Name = "Bermudian Dollar"; Decimals = 2};
    {Currency = BND; Number = 096; Name = "Brunei Dollar"; Decimals = 2};
    {Currency = BOB; Number = 068; Name = "Boliviano"; Decimals = 2};
    {Currency = BOV; Number = 984; Name = "Mvdol"; Decimals = 2};
    {Currency = BRL; Number = 986; Name = "Brazilian Real"; Decimals = 2};
    {Currency = BSD; Number = 044; Name = "Bahamian Dollar"; Decimals = 2};
    {Currency = BTN; Number = 064; Name = "Ngultrum"; Decimals = 2};
    {Currency = BWP; Number = 072; Name = "Pula"; Decimals = 2};
    {Currency = BYN; Number = 933; Name = "Belarusian Ruble"; Decimals = 2};
    {Currency = BZD; Number = 084; Name = "Belize Dollar"; Decimals = 2};
    {Currency = CAD; Number = 124; Name = "Canadian Dollar"; Decimals = 2};
    {Currency = CDF; Number = 976; Name = "Congolese Franc"; Decimals = 2};
    {Currency = CHE; Number = 947; Name = "WIR Euro"; Decimals = 2};
    {Currency = CHF; Number = 756; Name = "Swiss Franc"; Decimals = 2};
    {Currency = CHW; Number = 948; Name = "WIR Franc"; Decimals = 2};
    {Currency = CLF; Number = 990; Name = "Unidad de Fomento"; Decimals = 4};
    {Currency = CLP; Number = 152; Name = "Chilean Peso"; Decimals = 0};
    {Currency = CNY; Number = 156; Name = "Yuan Renminbi"; Decimals = 2};
    {Currency = COP; Number = 170; Name = "Colombian Peso"; Decimals = 2};
    {Currency = COU; Number = 970; Name = "Unidad de Valor Real"; Decimals = 2};
    {Currency = CRC; Number = 188; Name = "Costa Rican Colon"; Decimals = 2};
    {Currency = CUC; Number = 931; Name = "Peso Convertible"; Decimals = 2};
    {Currency = CUP; Number = 192; Name = "Cuban Peso"; Decimals = 2};
    {Currency = CVE; Number = 132; Name = "Cabo Verde Escudo"; Decimals = 2};
    {Currency = CZK; Number = 203; Name = "Czech Koruna"; Decimals = 2};
    {Currency = DJF; Number = 262; Name = "Djibouti Franc"; Decimals = 0};
    {Currency = DKK; Number = 208; Name = "Danish Krone"; Decimals = 2};
    {Currency = DOP; Number = 214; Name = "Dominican Peso"; Decimals = 2};
    {Currency = DZD; Number = 012; Name = "Algerian Dinar"; Decimals = 2};
    {Currency = EGP; Number = 818; Name = "Egyptian Pound"; Decimals = 2};
    {Currency = ERN; Number = 232; Name = "Nakfa"; Decimals = 2};
    {Currency = ETB; Number = 230; Name = "Ethiopian Birr"; Decimals = 2};
    {Currency = EUR; Number = 978; Name = "Euro"; Decimals = 2};
    {Currency = FJD; Number = 242; Name = "Fiji Dollar"; Decimals = 2};
    {Currency = FKP; Number = 238; Name = "Falkland Islands Pound"; Decimals = 2};
    {Currency = GBP; Number = 826; Name = "Pound Sterling"; Decimals = 2};
    {Currency = GEL; Number = 981; Name = "Lari"; Decimals = 2};
    {Currency = GHS; Number = 936; Name = "Ghana Cedi"; Decimals = 2};
    {Currency = GIP; Number = 292; Name = "Gibraltar Pound"; Decimals = 2};
    {Currency = GMD; Number = 270; Name = "Dalasi"; Decimals = 2};
    {Currency = GNF; Number = 324; Name = "Guinea Franc"; Decimals = 0};
    {Currency = GTQ; Number = 320; Name = "Quetzal"; Decimals = 2};
    {Currency = GYD; Number = 328; Name = "Guyana Dollar"; Decimals = 2};
    {Currency = HKD; Number = 344; Name = "Hong Kong Dollar"; Decimals = 2};
    {Currency = HNL; Number = 340; Name = "Lempira"; Decimals = 2};
    {Currency = HRK; Number = 191; Name = "Kuna"; Decimals = 2};
    {Currency = HTG; Number = 332; Name = "Gourde"; Decimals = 2};
    {Currency = HUF; Number = 348; Name = "Forint"; Decimals = 2};
    {Currency = IDR; Number = 360; Name = "Rupiah"; Decimals = 2};
    {Currency = ILS; Number = 376; Name = "New Israeli Sheqel"; Decimals = 2};
    {Currency = INR; Number = 356; Name = "Indian Rupee"; Decimals = 2};
    {Currency = IQD; Number = 368; Name = "Iraqi Dinar"; Decimals = 3};
    {Currency = IRR; Number = 364; Name = "Iranian Rial"; Decimals = 2};
    {Currency = ISK; Number = 352; Name = "Iceland Krona"; Decimals = 0};
    {Currency = JMD; Number = 388; Name = "Jamaican Dollar"; Decimals = 2};
    {Currency = JOD; Number = 400; Name = "Jordanian Dinar"; Decimals = 3};
    {Currency = JPY; Number = 392; Name = "Yen"; Decimals = 0};
    {Currency = KES; Number = 404; Name = "Kenyan Shilling"; Decimals = 2};
    {Currency = KGS; Number = 417; Name = "Som"; Decimals = 2};
    {Currency = KHR; Number = 116; Name = "Riel"; Decimals = 2};
    {Currency = KMF; Number = 174; Name = "Comoro Franc"; Decimals = 0};
    {Currency = KPW; Number = 408; Name = "North Korean Won"; Decimals = 2};
    {Currency = KRW; Number = 410; Name = "Won"; Decimals = 0};
    {Currency = KWD; Number = 414; Name = "Kuwaiti Dinar"; Decimals = 3};
    {Currency = KYD; Number = 136; Name = "Cayman Islands Dollar"; Decimals = 2};
    {Currency = KZT; Number = 398; Name = "Tenge"; Decimals = 2};
    {Currency = LAK; Number = 418; Name = "Kip"; Decimals = 2};
    {Currency = LBP; Number = 422; Name = "Lebanese Pound"; Decimals = 2};
    {Currency = LKR; Number = 144; Name = "Sri Lanka Rupee"; Decimals = 2};
    {Currency = LRD; Number = 430; Name = "Liberian Dollar"; Decimals = 2};
    {Currency = LSL; Number = 426; Name = "Loti"; Decimals = 2};
    {Currency = LYD; Number = 434; Name = "Libyan Dinar"; Decimals = 3};
    {Currency = MAD; Number = 504; Name = "Moroccan Dirham"; Decimals = 2};
    {Currency = MDL; Number = 498; Name = "Moldovan Leu"; Decimals = 2};
    {Currency = MGA; Number = 969; Name = "Malagasy Ariary"; Decimals = 2};
    {Currency = MKD; Number = 807; Name = "Denar"; Decimals = 2};
    {Currency = MMK; Number = 104; Name = "Kyat"; Decimals = 2};
    {Currency = MNT; Number = 496; Name = "Tugrik"; Decimals = 2};
    {Currency = MOP; Number = 446; Name = "Pataca"; Decimals = 2};
    {Currency = MRO; Number = 478; Name = "Ouguiya"; Decimals = 2};
    {Currency = MUR; Number = 480; Name = "Mauritius Rupee"; Decimals = 2};
    {Currency = MVR; Number = 462; Name = "Rufiyaa"; Decimals = 2};
    {Currency = MWK; Number = 454; Name = "Malawi Kwacha"; Decimals = 2};
    {Currency = MXN; Number = 484; Name = "Mexican Peso"; Decimals = 2};
    {Currency = MYR; Number = 458; Name = "Malaysian Ringgit"; Decimals = 2};
    {Currency = MZN; Number = 943; Name = "Mozambique Metical"; Decimals = 2};
    {Currency = NAD; Number = 516; Name = "Namibia Dollar"; Decimals = 2};
    {Currency = NGN; Number = 566; Name = "Naira"; Decimals = 2};
    {Currency = NIO; Number = 558; Name = "Cordoba Oro"; Decimals = 2};
    {Currency = NOK; Number = 578; Name = "Norwegian Krone"; Decimals = 2};
    {Currency = NPR; Number = 524; Name = "Nepalese Rupee"; Decimals = 2};
    {Currency = NZD; Number = 554; Name = "New Zealand Dollar"; Decimals = 2};
    {Currency = OMR; Number = 512; Name = "Rial Omani"; Decimals = 3};
    {Currency = PAB; Number = 590; Name = "Balboa"; Decimals = 2};
    {Currency = PEN; Number = 604; Name = "Sol"; Decimals = 2};
    {Currency = PGK; Number = 598; Name = "Kina"; Decimals = 2};
    {Currency = PHP; Number = 608; Name = "Philippine Peso"; Decimals = 2};
    {Currency = PKR; Number = 586; Name = "Pakistan Rupee"; Decimals = 2};
    {Currency = PLN; Number = 985; Name = "Zloty"; Decimals = 2};
    {Currency = PYG; Number = 600; Name = "Guarani"; Decimals = 0};
    {Currency = QAR; Number = 634; Name = "Qatari Rial"; Decimals = 2};
    {Currency = RON; Number = 946; Name = "Romanian Leu"; Decimals = 2};
    {Currency = RSD; Number = 941; Name = "Serbian Dinar"; Decimals = 2};
    {Currency = RUB; Number = 643; Name = "Russian Ruble"; Decimals = 2};
    {Currency = RWF; Number = 646; Name = "Rwanda Franc"; Decimals = 0};
    {Currency = SAR; Number = 682; Name = "Saudi Riyal"; Decimals = 2};
    {Currency = SBD; Number = 090; Name = "Solomon Islands Dollar"; Decimals = 2};
    {Currency = SCR; Number = 690; Name = "Seychelles Rupee"; Decimals = 2};
    {Currency = SDG; Number = 938; Name = "Sudanese Pound"; Decimals = 2};
    {Currency = SEK; Number = 752; Name = "Swedish Krona"; Decimals = 2};
    {Currency = SGD; Number = 702; Name = "Singapore Dollar"; Decimals = 2};
    {Currency = SHP; Number = 654; Name = "Saint Helena Pound"; Decimals = 2};
    {Currency = SLL; Number = 694; Name = "Leone"; Decimals = 2};
    {Currency = SOS; Number = 706; Name = "Somali Shilling"; Decimals = 2};
    {Currency = SRD; Number = 968; Name = "Surinam Dollar"; Decimals = 2};
    {Currency = SSP; Number = 728; Name = "South Sudanese Pound"; Decimals = 2};
    {Currency = STD; Number = 678; Name = "Dobra"; Decimals = 2};
    {Currency = SVC; Number = 222; Name = "El Salvador Colon"; Decimals = 2};
    {Currency = SYP; Number = 760; Name = "Syrian Pound"; Decimals = 2};
    {Currency = SZL; Number = 748; Name = "Lilangeni"; Decimals = 2};
    {Currency = THB; Number = 764; Name = "Baht"; Decimals = 2};
    {Currency = TJS; Number = 972; Name = "Somoni"; Decimals = 2};
    {Currency = TMT; Number = 934; Name = "Turkmenistan New Manat"; Decimals = 2};
    {Currency = TND; Number = 788; Name = "Tunisian Dinar"; Decimals = 3};
    {Currency = TOP; Number = 776; Name = "Pa’anga"; Decimals = 2};
    {Currency = TRY; Number = 949; Name = "Turkish Lira"; Decimals = 2};
    {Currency = TTD; Number = 780; Name = "Trinidad and Tobago Dollar"; Decimals = 2};
    {Currency = TWD; Number = 901; Name = "New Taiwan Dollar"; Decimals = 2};
    {Currency = TZS; Number = 834; Name = "Tanzanian Shilling"; Decimals = 2};
    {Currency = UAH; Number = 980; Name = "Hryvnia"; Decimals = 2};
    {Currency = UGX; Number = 800; Name = "Uganda Shilling"; Decimals = 0};
    {Currency = USD; Number = 840; Name = "US Dollar"; Decimals = 2};
    {Currency = UYU; Number = 858; Name = "Peso Uruguayo"; Decimals = 2};
    {Currency = UZS; Number = 860; Name = "Uzbekistan Sum"; Decimals = 2};
    {Currency = VEF; Number = 937; Name = "Bolívar"; Decimals = 2};
    {Currency = VND; Number = 704; Name = "Dong"; Decimals = 0};
    {Currency = VUV; Number = 548; Name = "Vatu"; Decimals = 0};
    {Currency = WST; Number = 882; Name = "Tala"; Decimals = 2};
    {Currency = XAF; Number = 950; Name = "CFA Franc BEAC"; Decimals = 0};
    {Currency = XCD; Number = 951; Name = "East Caribbean Dollar"; Decimals = 2};
    {Currency = XOF; Number = 952; Name = "CFA Franc BCEAO"; Decimals = 0};
    {Currency = XPF; Number = 953; Name = "CFP Franc"; Decimals = 0};
    {Currency = XTS; Number = 886; Name = "Testing"; Decimals = 963};
    {Currency = XXX; Number = 886; Name = "No Currency Specified"; Decimals = 999};
    {Currency = YER; Number = 886; Name = "Yemeni Rial"; Decimals = 2};
    {Currency = ZAR; Number = 710; Name = "Rand"; Decimals = 2};
    {Currency = ZMW; Number = 967; Name = "Zambian Kwacha"; Decimals = 2};
    {Currency = ZWL; Number = 932; Name = "Zimbabwe Dollar"; Decimals = 2}] 
        |> List.map (fun r -> (r.Currency,r) )
        |> Map.ofList

let currencyRec cur =
    Currencies.Item cur
