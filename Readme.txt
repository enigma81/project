Prošao sam kroz vaše izmene:

1.       Person.cs i Student.cs

a.       Maknut abstract modifier sa property-a Person klase, nepotrebno je u ovom sluèaju.

2.       StudentIdGenerator.cs

a.       Metoda setId() je nepotrebna i nije joj ime po c# konvencijama

3.       ValidationMessage.cs

a.       Neka bude obièna klasa (POCO) sa dva property-a.

b.      Ona ne treba držati kolekciju poruka, ona samo služi za prijenos informacije o validaciji.

4.       Validator.cs

a.       Izmjeniti metode tako da kreiraju ValidationMessage objekt i vraæaju kao rezultat validacija (GetInstance je nepotrebno). Error poruke možete držati u privatnoj Resource klasi, koja ima public const fieldove.