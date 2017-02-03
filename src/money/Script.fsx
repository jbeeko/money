#load "money.fs"
open Money
open System










let data = "UAE Dirham,AED,784,2
Afghani,AFN,971,2
Lek,ALL,008,2
Armenian Dram,AMD,051,2
Netherlands Antillean Guilder,ANG,532,2
Netherlands Antillean Guilder,ANG,532,2
Kwanza,AOA,973,2
Argentine Peso,ARS,032,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Australian Dollar,AUD,036,2
Aruban Florin,AWG,533,2
Azerbaijanian Manat,AZN,944,2
Convertible Mark,BAM,977,2
Barbados Dollar,BBD,052,2
Taka,BDT,050,2
Bulgarian Lev,BGN,975,2
Bahraini Dinar,BHD,048,3
Burundi Franc,BIF,108,0
Bermudian Dollar,BMD,060,2
Brunei Dollar,BND,096,2
Boliviano,BOB,068,2
Mvdol,BOV,984,2
Brazilian Real,BRL,986,2
Bahamian Dollar,BSD,044,2
Ngultrum,BTN,064,2
Pula,BWP,072,2
Belarusian Ruble,BYN,933,2
Belize Dollar,BZD,084,2
Canadian Dollar,CAD,124,2
Congolese Franc,CDF,976,2
WIR Euro,CHE,947,2
Swiss Franc,CHF,756,2
Swiss Franc,CHF,756,2
WIR Franc,CHW,948,2
Unidad de Fomento,CLF,990,4
Chilean Peso,CLP,152,0
Yuan Renminbi,CNY,156,2
Colombian Peso,COP,170,2
Unidad de Valor Real,COU,970,2
Costa Rican Colon,CRC,188,2
Peso Convertible,CUC,931,2
Cuban Peso,CUP,192,2
Cabo Verde Escudo,CVE,132,2
Czech Koruna,CZK,203,2
Djibouti Franc,DJF,262,0
Danish Krone,DKK,208,2
Danish Krone,DKK,208,2
Danish Krone,DKK,208,2
Dominican Peso,DOP,214,2
Algerian Dinar,DZD,012,2
Egyptian Pound,EGP,818,2
Nakfa,ERN,232,2
Ethiopian Birr,ETB,230,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Euro,EUR,978,2
Fiji Dollar,FJD,242,2
Falkland Islands Pound,FKP,238,2
Pound Sterling,GBP,826,2
Pound Sterling,GBP,826,2
Pound Sterling,GBP,826,2
Pound Sterling,GBP,826,2
Lari,GEL,981,2
Ghana Cedi,GHS,936,2
Gibraltar Pound,GIP,292,2
Dalasi,GMD,270,2
Guinea Franc,GNF,324,0
Quetzal,GTQ,320,2
Guyana Dollar,GYD,328,2
Hong Kong Dollar,HKD,344,2
Lempira,HNL,340,2
Kuna,HRK,191,2
Gourde,HTG,332,2
Forint,HUF,348,2
Rupiah,IDR,360,2
New Israeli Sheqel,ILS,376,2
Indian Rupee,INR,356,2
Indian Rupee,INR,356,2
Iraqi Dinar,IQD,368,3
Iranian Rial,IRR,364,2
Iceland Krona,ISK,352,0
Jamaican Dollar,JMD,388,2
Jordanian Dinar,JOD,400,3
Yen,JPY,392,0
Kenyan Shilling,KES,404,2
Som,KGS,417,2
Riel,KHR,116,2
Comoro Franc,KMF,174,0
North Korean Won,KPW,408,2
Won,KRW,410,0
Kuwaiti Dinar,KWD,414,3
Cayman Islands Dollar,KYD,136,2
Tenge,KZT,398,2
Kip,LAK,418,2
Lebanese Pound,LBP,422,2
Sri Lanka Rupee,LKR,144,2
Liberian Dollar,LRD,430,2
Loti,LSL,426,2
Libyan Dinar,LYD,434,3
Moroccan Dirham,MAD,504,2
Moroccan Dirham,MAD,504,2
Moldovan Leu,MDL,498,2
Malagasy Ariary,MGA,969,2
Denar,MKD,807,2
Kyat,MMK,104,2
Tugrik,MNT,496,2
Pataca,MOP,446,2
Ouguiya,MRO,478,2
Mauritius Rupee,MUR,480,2
Rufiyaa,MVR,462,2
Malawi Kwacha,MWK,454,2
Mexican Peso,MXN,484,2
Mexican Unidad de Inversion (UDI),MXV,979,2
Malaysian Ringgit,MYR,458,2
Mozambique Metical,MZN,943,2
Namibia Dollar,NAD,516,2
Naira,NGN,566,2
Cordoba Oro,NIO,558,2
Norwegian Krone,NOK,578,2
Norwegian Krone,NOK,578,2
Norwegian Krone,NOK,578,2
Nepalese Rupee,NPR,524,2
New Zealand Dollar,NZD,554,2
New Zealand Dollar,NZD,554,2
New Zealand Dollar,NZD,554,2
New Zealand Dollar,NZD,554,2
New Zealand Dollar,NZD,554,2
Rial Omani,OMR,512,3
Balboa,PAB,590,2
Sol,PEN,604,2
Kina,PGK,598,2
Philippine Peso,PHP,608,2
Pakistan Rupee,PKR,586,2
Zloty,PLN,985,2
Guarani,PYG,600,0
Qatari Rial,QAR,634,2
Romanian Leu,RON,946,2
Serbian Dinar,RSD,941,2
Russian Ruble,RUB,643,2
Rwanda Franc,RWF,646,0
Saudi Riyal,SAR,682,2
Solomon Islands Dollar,SBD,090,2
Seychelles Rupee,SCR,690,2
Sudanese Pound,SDG,938,2
Swedish Krona,SEK,752,2
Singapore Dollar,SGD,702,2
Saint Helena Pound,SHP,654,2
Leone,SLL,694,2
Somali Shilling,SOS,706,2
Surinam Dollar,SRD,968,2
South Sudanese Pound,SSP,728,2
Dobra,STD,678,2
El Salvador Colon,SVC,222,2
Syrian Pound,SYP,760,2
Lilangeni,SZL,748,2
Baht,THB,764,2
Somoni,TJS,972,2
Turkmenistan New Manat,TMT,934,2
Tunisian Dinar,TND,788,3
Pa’anga,TOP,776,2
Turkish Lira,TRY,949,2
Trinidad and Tobago Dollar,TTD,780,2
New Taiwan Dollar,TWD,901,2
Tanzanian Shilling,TZS,834,2
Hryvnia,UAH,980,2
Uganda Shilling,UGX,800,0
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
US Dollar,USD,840,2
Uruguay Peso en Unidades Indexadas (URUIURUI),UYI,940,0
Peso Uruguayo,UYU,858,2
Uzbekistan Sum,UZS,860,2
Bolívar,VEF,937,2
Dong,VND,704,0
Vatu,VUV,548,0
Tala,WST,882,2
CFA Franc BEAC,XAF,950,0
CFA Franc BEAC,XAF,950,0
CFA Franc BEAC,XAF,950,0
CFA Franc BEAC,XAF,950,0
CFA Franc BEAC,XAF,950,0
CFA Franc BEAC,XAF,950,0
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
East Caribbean Dollar,XCD,951,2
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFA Franc BCEAO,XOF,952,0
CFP Franc,XPF,953,0
CFP Franc,XPF,953,0
CFP Franc,XPF,953,0
Yemeni Rial,YER,886,2
Rand,ZAR,710,2
Rand,ZAR,710,2
Rand,ZAR,710,2
Zambian Kwacha,ZMW,967,2
Zimbabwe Dollar,ZWL,932,2"

let lines = Array.toSeq (data.Split [|'\n'|])

let recs = seq {   
        for line in lines do 
        yield line.Split [|','|]}



let r = "Zimbabwe Dollar,ZWL,932,2".Split [|','|]
sprintf "let %s = {Code = %s; Number = %s; Name = %s; Decimals = %s}" r.[1] r.[1] r.[2] r.[0] r.[3]

"Zimbabwe Dollar,ZWL,932,2"
