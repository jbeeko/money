module Country

type Country =
    | AD | AE | AF | AG | AI | AL | AM | AO | AQ | AR | AS | AT | AU | AW | AX | AZ 
    | BA | BB | BD | BE | BF | BG | BH | BI | BJ | BL | BM | BN | BO | BR | BS | BT | BV | BW | BY | BZ 
    | CA | CC | CD | CF | CG | CH | CI | CK | CL | CM | CN | CO | CR | CU | CV | CW | CX | CY | CZ 
    | DE | DJ | DK | DM | DO | DZ 
    | EC | EE | EG | EH | ER | ES | ET 
    | FI | FJ | FK | FM | FO | FR 
    | GA | GB | GD | GE | GF | GG | GH | GI | GL | GM | GN | GP | GQ | GR | GS | GT | GU | GW | GY 
    | HK | HM | HN | HR | HT | HU 
    | ID | IE | IL | IM | IN | IO | IQ | IR | IS | IT 
    | JE | JM | JO | JP 
    | KE | KG | KH | KI | KM | KN | KP | KR | KW | KY | KZ 
    | LA | LB | LC | LI | LK | LR | LS | LT | LU | LV | LY 
    | MA | MC | MD | ME | MF | MG | MH | MK | ML | MM | MN | MO | MP | MQ | MR | MS | MT | MU | MV | MW | MX | MY | MZ 
    | NA | NC | NE | NF | NG | NI | NL | NO | NP | NR | NU | NZ 
    | OM 
    | PA | PE | PF | PG | PH | PK | PL | PM | PN | PR | PT | PW | PY 
    | QA 
    | RE | RO | RS | RU | RW 
    | SA | SB | SC | SD | SE | SG | SI | SJ | SK | SL | SM | SN | SO | SR | SS | ST | SV | SX | SY | SZ 
    | TC | TD | TF | TG | TH | TJ | TK | TL | TM | TN | TO | TR | TT | TV | TW | TZ
    | UA | UG | UM | US | UY | UZ 
    | VA | VC | VE | VG | VI | VN | VU 
    | WF | WS 
    | YE | YT | ZA | ZM | ZW
    //Synthetic none ISO Countries
    | EU

[<StructuredFormatDisplay("{Code}")>]
type CountryDetails = {
    Code : Country;
    Number : int 
    Name : string
}

let Countries = 
    [
    {Code = AD; Number = 020; Name = "Andorra"};
    {Code = AE; Number = 784; Name = "United Arab Emirates"};
    {Code = AF; Number = 004; Name = "Afghanistan"};
    {Code = AG; Number = 028; Name = "Antigua and Barbuda"};
    {Code = AI; Number = 660; Name = "Anguilla"};
    {Code = AL; Number = 008; Name = "Albania"};
    {Code = AM; Number = 051; Name = "Armenia"};
    {Code = AO; Number = 024; Name = "Angola"};
    {Code = AQ; Number = 010; Name = "Antarctica"};
    {Code = AR; Number = 032; Name = "Argentina"};
    {Code = AS; Number = 016; Name = "American Samoa"};
    {Code = AT; Number = 040; Name = "Austria"};
    {Code = AU; Number = 036; Name = "Australia"};
    {Code = AW; Number = 533; Name = "Aruba"};
    {Code = AX; Number = 248; Name = "Åland Islands"};
    {Code = AZ; Number = 031; Name = "Azerbaijan"};
    {Code = BA; Number = 070; Name = "Bosnia and Herzegovina"};
    {Code = BB; Number = 052; Name = "Barbados"};
    {Code = BD; Number = 050; Name = "Bangladesh"};
    {Code = BE; Number = 056; Name = "Belgium"};
    {Code = BF; Number = 854; Name = "Burkina Faso"};
    {Code = BG; Number = 100; Name = "Bulgaria"};
    {Code = BH; Number = 048; Name = "Bahrain"};
    {Code = BI; Number = 108; Name = "Burundi"};
    {Code = BJ; Number = 204; Name = "Benin"};
    {Code = BL; Number = 652; Name = "Saint Barthélemy"};
    {Code = BM; Number = 060; Name = "Bermuda"};
    {Code = BN; Number = 096; Name = "Brunei Darussalam"};
    {Code = BO; Number = 068; Name = "Bolivia"};
    {Code = BR; Number = 076; Name = "Brazil"};
    {Code = BS; Number = 044; Name = "Bahamas"};
    {Code = BT; Number = 064; Name = "Bhutan"};
    {Code = BV; Number = 074; Name = "Bouvet Island"};
    {Code = BW; Number = 072; Name = "Botswana"};
    {Code = BY; Number = 112; Name = "Belarus"};
    {Code = BZ; Number = 084; Name = "Belize"};
    {Code = CA; Number = 124; Name = "Canada"};
    {Code = CC; Number = 166; Name = "Cocos Islands"};
    {Code = CD; Number = 180; Name = "DR Congo"};
    {Code = CF; Number = 140; Name = "Central African Republic"};
    {Code = CG; Number = 178; Name = "Congo"};
    {Code = CH; Number = 756; Name = "Switzerland"};
    {Code = CI; Number = 384; Name = "Côte d'Ivoire"};
    {Code = CK; Number = 184; Name = "Cook Islands"};
    {Code = CL; Number = 152; Name = "Chile"};
    {Code = CM; Number = 120; Name = "Cameroon"};
    {Code = CN; Number = 156; Name = "China"};
    {Code = CO; Number = 170; Name = "Colombia"};
    {Code = CR; Number = 188; Name = "Costa Rica"};
    {Code = CU; Number = 192; Name = "Cuba"};
    {Code = CV; Number = 132; Name = "Cabo Verde"};
    {Code = CW; Number = 531; Name = "Curaçao"};
    {Code = CX; Number = 162; Name = "Christmas Island"};
    {Code = CY; Number = 196; Name = "Cyprus"};
    {Code = CZ; Number = 203; Name = "Czechia"};
    {Code = DE; Number = 276; Name = "Germany"};
    {Code = DJ; Number = 262; Name = "Djibouti"};
    {Code = DK; Number = 208; Name = "Denmark"};
    {Code = DM; Number = 212; Name = "Dominica"};
    {Code = DO; Number = 214; Name = "Dominican Republic"};
    {Code = DZ; Number = 012; Name = "Algeria"};
    {Code = EC; Number = 218; Name = "Ecuador"};
    {Code = EE; Number = 233; Name = "Estonia"};
    {Code = EG; Number = 818; Name = "Egypt"};
    {Code = EH; Number = 732; Name = "Western Sahara"};
    {Code = ER; Number = 232; Name = "Eritrea"};
    {Code = ES; Number = 724; Name = "Spain"};
    {Code = ET; Number = 231; Name = "Ethiopia"};
    {Code = FI; Number = 246; Name = "Finland"};
    {Code = FJ; Number = 242; Name = "Fiji"};
    {Code = FK; Number = 238; Name = "Falkland Islands"};
    {Code = FM; Number = 583; Name = "Micronesia"};
    {Code = FO; Number = 234; Name = "Faroe Islands"};
    {Code = FR; Number = 250; Name = "France"};
    {Code = GA; Number = 266; Name = "Gabon"};
    {Code = GB; Number = 826; Name = "United Kingdom"};
    {Code = GD; Number = 308; Name = "Grenada"};
    {Code = GE; Number = 268; Name = "Georgia"};
    {Code = GF; Number = 254; Name = "French Guiana"};
    {Code = GG; Number = 831; Name = "Guernsey"};
    {Code = GH; Number = 288; Name = "Ghana"};
    {Code = GI; Number = 292; Name = "Gibraltar"};
    {Code = GL; Number = 304; Name = "Greenland"};
    {Code = GM; Number = 270; Name = "Gambia"};
    {Code = GN; Number = 324; Name = "Guinea"};
    {Code = GP; Number = 312; Name = "Guadeloupe"};
    {Code = GQ; Number = 226; Name = "Equatorial Guinea"};
    {Code = GR; Number = 300; Name = "Greece"};
    {Code = GS; Number = 239; Name = "South Georgia and the South Sandwich Islands"};
    {Code = GT; Number = 320; Name = "Guatemala"};
    {Code = GU; Number = 316; Name = "Guam"};
    {Code = GW; Number = 624; Name = "Guinea-Bissau"};
    {Code = GY; Number = 328; Name = "Guyana"};
    {Code = HK; Number = 344; Name = "Hong Kong"};
    {Code = HM; Number = 334; Name = "Heard Island and McDonald Islands"};
    {Code = HN; Number = 340; Name = "Honduras"};
    {Code = HR; Number = 191; Name = "Croatia"};
    {Code = HT; Number = 332; Name = "Haiti"};
    {Code = HU; Number = 348; Name = "Hungary"};
    {Code = ID; Number = 360; Name = "Indonesia"};
    {Code = IE; Number = 372; Name = "Ireland"};
    {Code = IL; Number = 376; Name = "Israel"};
    {Code = IM; Number = 833; Name = "Isle of Man"};
    {Code = IN; Number = 356; Name = "India"};
    {Code = IO; Number = 086; Name = "British Indian Ocean Territory"};
    {Code = IQ; Number = 368; Name = "Iraq"};
    {Code = IR; Number = 364; Name = "Iran"};
    {Code = IS; Number = 352; Name = "Iceland"};
    {Code = IT; Number = 380; Name = "Italy"};
    {Code = JE; Number = 832; Name = "Jersey"};
    {Code = JM; Number = 388; Name = "Jamaica"};
    {Code = JO; Number = 400; Name = "Jordan"};
    {Code = JP; Number = 392; Name = "Japan"};
    {Code = KE; Number = 404; Name = "Kenya"};
    {Code = KG; Number = 417; Name = "Kyrgyzstan"};
    {Code = KH; Number = 116; Name = "Cambodia"};
    {Code = KI; Number = 296; Name = "Kiribati"};
    {Code = KM; Number = 174; Name = "Comoros"};
    {Code = KN; Number = 659; Name = "Saint Kitts and Nevis"};
    {Code = KP; Number = 408; Name = "North Korea"};
    {Code = KR; Number = 410; Name = "Korea"};
    {Code = KW; Number = 414; Name = "Kuwait"};
    {Code = KY; Number = 136; Name = "Cayman Islands"};
    {Code = KZ; Number = 398; Name = "Kazakhstan"};
    {Code = LA; Number = 418; Name = "Lao People's Democratic Republic"};
    {Code = LB; Number = 422; Name = "Lebanon"};
    {Code = LC; Number = 662; Name = "Saint Lucia"};
    {Code = LI; Number = 438; Name = "Liechtenstein"};
    {Code = LK; Number = 144; Name = "Sri Lanka"};
    {Code = LR; Number = 430; Name = "Liberia"};
    {Code = LS; Number = 426; Name = "Lesotho"};
    {Code = LT; Number = 440; Name = "Lithuania"};
    {Code = LU; Number = 442; Name = "Luxembourg"};
    {Code = LV; Number = 428; Name = "Latvia"};
    {Code = LY; Number = 434; Name = "Libya"};
    {Code = MA; Number = 504; Name = "Morocco"};
    {Code = MC; Number = 492; Name = "Monaco"};
    {Code = MD; Number = 498; Name = "Moldova"};
    {Code = ME; Number = 499; Name = "Montenegro"};
    {Code = MF; Number = 663; Name = "Saint Martin (French part)"};
    {Code = MG; Number = 450; Name = "Madagascar"};
    {Code = MH; Number = 584; Name = "Marshall Islands"};
    {Code = MK; Number = 807; Name = "Macedonia"};
    {Code = ML; Number = 466; Name = "Mali"};
    {Code = MM; Number = 104; Name = "Myanmar"};
    {Code = MN; Number = 496; Name = "Mongolia"};
    {Code = MO; Number = 446; Name = "Macao"};
    {Code = MP; Number = 580; Name = "Northern Mariana Islands"};
    {Code = MQ; Number = 474; Name = "Martinique"};
    {Code = MR; Number = 478; Name = "Mauritania"};
    {Code = MS; Number = 500; Name = "Montserrat"};
    {Code = MT; Number = 470; Name = "Malta"};
    {Code = MU; Number = 480; Name = "Mauritius"};
    {Code = MV; Number = 462; Name = "Maldives"};
    {Code = MW; Number = 454; Name = "Malawi"};
    {Code = MX; Number = 484; Name = "Mexico"};
    {Code = MY; Number = 458; Name = "Malaysia"};
    {Code = MZ; Number = 508; Name = "Mozambique"};
    {Code = NA; Number = 516; Name = "Namibia"};
    {Code = NC; Number = 540; Name = "New Caledonia"};
    {Code = NE; Number = 562; Name = "Niger"};
    {Code = NF; Number = 574; Name = "Norfolk Island"};
    {Code = NG; Number = 566; Name = "Nigeria"};
    {Code = NI; Number = 558; Name = "Nicaragua"};
    {Code = NL; Number = 528; Name = "Netherlands"};
    {Code = NO; Number = 578; Name = "Norway"};
    {Code = NP; Number = 524; Name = "Nepal"};
    {Code = NR; Number = 520; Name = "Nauru"};
    {Code = NU; Number = 570; Name = "Niue"};
    {Code = NZ; Number = 554; Name = "New Zealand"};
    {Code = OM; Number = 512; Name = "Oman"};
    {Code = PA; Number = 591; Name = "Panama"};
    {Code = PE; Number = 604; Name = "Peru"};
    {Code = PF; Number = 258; Name = "French Polynesia"};
    {Code = PG; Number = 598; Name = "Papua New Guinea"};
    {Code = PH; Number = 608; Name = "Philippines"};
    {Code = PK; Number = 586; Name = "Pakistan"};
    {Code = PL; Number = 616; Name = "Poland"};
    {Code = PM; Number = 666; Name = "Saint Pierre and Miquelon"};
    {Code = PN; Number = 612; Name = "Pitcairn"};
    {Code = PR; Number = 630; Name = "Puerto Rico"};
    {Code = PT; Number = 620; Name = "Portugal"};
    {Code = PW; Number = 585; Name = "Palau"};  
    {Code = PW; Number = 585; Name = "Palau"};
    {Code = PY; Number = 600; Name = "Paraguay"};
    {Code = QA; Number = 634; Name = "Qatar"};
    {Code = RE; Number = 638; Name = "Réunion"};
    {Code = RO; Number = 642; Name = "Romania"};
    {Code = RS; Number = 688; Name = "Serbia"};
    {Code = RU; Number = 643; Name = "Russian Federation"};
    {Code = RW; Number = 646; Name = "Rwanda"};
    {Code = SA; Number = 682; Name = "Saudi Arabia"};
    {Code = SB; Number = 090; Name = "Solomon Islands"};
    {Code = SC; Number = 690; Name = "Seychelles"};
    {Code = SD; Number = 729; Name = "Sudan"};
    {Code = SE; Number = 752; Name = "Sweden"};
    {Code = SG; Number = 702; Name = "Singapore"};
    {Code = SI; Number = 705; Name = "Slovenia"};
    {Code = SJ; Number = 744; Name = "Svalbard and Jan Mayen"};
    {Code = SK; Number = 703; Name = "Slovakia"};
    {Code = SL; Number = 694; Name = "Sierra Leone"};
    {Code = SM; Number = 674; Name = "San Marino"};
    {Code = SN; Number = 686; Name = "Senegal"};
    {Code = SO; Number = 706; Name = "Somalia"};
    {Code = SR; Number = 740; Name = "Suriname"};
    {Code = SS; Number = 728; Name = "South Sudan"};
    {Code = ST; Number = 678; Name = "Sao Tome and Principe"};
    {Code = SV; Number = 222; Name = "El Salvador"};
    {Code = SX; Number = 534; Name = "Dutch Sint Maarten"};
    {Code = SY; Number = 760; Name = "Syrian Arab Republic"};
    {Code = SZ; Number = 748; Name = "Swaziland"};
    {Code = TC; Number = 796; Name = "Turks and Caicos Islands"};
    {Code = TD; Number = 148; Name = "Chad"};
    {Code = TF; Number = 260; Name = "French Southern Territories"};
    {Code = TG; Number = 768; Name = "Togo"};
    {Code = TH; Number = 764; Name = "Thailand"};
    {Code = TJ; Number = 762; Name = "Tajikistan"};
    {Code = TK; Number = 772; Name = "Tokelau"};
    {Code = TL; Number = 626; Name = "Timor-Leste"};
    {Code = TM; Number = 795; Name = "Turkmenistan"};
    {Code = TN; Number = 788; Name = "Tunisia"};
    {Code = TO; Number = 776; Name = "Tonga"};
    {Code = TR; Number = 792; Name = "Turkey"};
    {Code = TT; Number = 780; Name = "Trinidad and Tobago"};
    {Code = TV; Number = 798; Name = "Tuvalu"};
    {Code = TW; Number = 158; Name = "Taiwan"};
    {Code = TZ; Number = 834; Name = "Tanzania"};
    {Code = UA; Number = 804; Name = "Ukraine"};
    {Code = UG; Number = 800; Name = "Uganda"};
    {Code = UM; Number = 581; Name = "United States Minor Outlying Islands"};
    {Code = US; Number = 840; Name = "United States of America"};
    {Code = UY; Number = 858; Name = "Uruguay"};
    {Code = UZ; Number = 860; Name = "Uzbekistan"};
    {Code = VA; Number = 336; Name = "Holy See"};
    {Code = VC; Number = 670; Name = "Saint Vincent and the Grenadines"};
    {Code = VE; Number = 862; Name = "Venezuela"};
    {Code = VG; Number = 092; Name = "British Virgin Islands"};
    {Code = VI; Number = 850; Name = "US Virgin Islands"};
    {Code = VN; Number = 704; Name = "Viet Nam"};
    {Code = VU; Number = 548; Name = "Vanuatu"};
    {Code = WF; Number = 876; Name = "Wallis and Futuna"};
    {Code = WS; Number = 882; Name = "Samoa"};
    {Code = YE; Number = 887; Name = "Yemen"};
    {Code = YT; Number = 175; Name = "Mayotte"};
    {Code = ZA; Number = 710; Name = "South Africa"};
    {Code = ZM; Number = 894; Name = "Zambia"};
    {Code = ZW; Number = 716; Name = "Zimbabwe"}]
        |> List.map (fun r -> (r.Code,r) )
        |> Map.ofList

let countryRec cntry =
    Countries.Item cntry
