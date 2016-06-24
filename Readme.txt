-       Validator klasa –  pogledati protected modifier

-       Validator klasa i child klase, ima dosta ponavljanja koda, to se može premjestiti u protected metodu na base klasi, koja ce postaviti poruku.

-       Validator klasa, vraæati novu instancu poruke.       

-       Mozda koristiti Pascal case za konstante ( prvo slovo veliko )

-       Kreiranje Id-a je bolje staviti u metodu, nego na property.

-       Sa singletona se metode mogu zvati direktno umjesto spremanja u field ... ( SingletonClass.Instance.Method() ) – OperationController linija 93

-       OperationController, ima ponavljanja koda, provjeriti koji dio se može premjestiti u methode.

-       Pogledati Console.WriteLine() i overloade. Može se i bez + operatora odraditi, èitljivije je