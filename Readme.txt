1.       Validation.cs

a.       Apsolutno je nepotrebno koristiti System.Reflection library u va�em slu�aju. Stoga, potrebno je izbaciti sve metode vezane uz njega. Potrebno je implementirati metode koje validiraju isklju�ivo jednu stvar poput GPA ili FirstName/LastName i dr.

2.       StudentContainer.cs

a.       Student Container, sortiranje studenata. Mozda bi bilo bolje napraviti dvije metode umjesto prosljedivanja byte-a. Ako se vec odlucite na prosljedivanje i granjanje iz switch statementa , bilo bi bolje koristiti Enum data type. https://msdn.microsoft.com/en-us/library/sbbt4032.aspx

3.       Najbolje bi bilo da krenete s implementacijom u Project.App solutionu, Program. Instancirajte Validation klasu tamo i krenite pisati kod, pa ve� vidite �to vam treba ili ne od metoda. Bilo bi dobro da metode iz Validation klase ne budu static ako kasnije planirate implementirati sve kroz interface. Za po�etak krenite pisati kod u Program.cs, o refaktoriranju i praksama se mo�e kasnije.