Pro�ao sam kroz va�e izmene:

1.       Person.cs i Student.cs

a.       Maknut abstract modifier sa property-a Person klase, nepotrebno je u ovom slu�aju.

2.       StudentIdGenerator.cs

a.       Metoda setId() je nepotrebna i nije joj ime po c# konvencijama

3.       ValidationMessage.cs

a.       Neka bude obi�na klasa (POCO) sa dva property-a.

b.      Ona ne treba dr�ati kolekciju poruka, ona samo slu�i za prijenos informacije o validaciji.

4.       Validator.cs

a.       Izmjeniti metode tako da kreiraju ValidationMessage objekt i vra�aju kao rezultat validacija (GetInstance je nepotrebno). Error poruke mo�ete dr�ati u privatnoj Resource klasi, koja ima public const fieldove.