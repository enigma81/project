1.       Console klasa ne bi trebala biti vidljiva i koristiti se u Project solutionu. Samo bi Project.App trebao imati operacije vezane za konzolu. Razmi�ljajte o tome kao da vam je Project solution service layer koji mo�ete kasnije koristiti i za druge platforme osim konzole ( Desktop winforms ili wpf, web itd... ). Sve one klase i/ili metode koje koriste direktno Console read ili write trebaju biti izmjenjene, premje�tene ili obrisane te nanovo napisana logika koja �e i��itivata ili upisivati u konzolu u Project.App projektu.

2.       S metodom SortStudentsList koju ste zakomentirali ste bili na dobrom putu. Probajte staviti rezultat te metode, to jest ono �to ona vrati u varijablu.

3.       Praksa imenovanja za klase , kao �to je Students je da budu u jednini.

4.       Probajte si pojednostavniti tako da vam Validator klase radi validaciju kao �to je ime ili broj, umjesto NewPerson, NewStudent klasa.

5.       SetValidationMessage mogu biti GetValidationMessage i vratiti novu instancu. Samim time se mo�e pojednostavniti StudentsValidator klasa i mo�e se izbje�i kori�tenje jedne jedine insance ValidatiorMessage klase.

6.       Klase StudentIdGenerator, Students (ispraviti ime prema to�ki 3.) i StudentContainer trebaju biti svaka u zasebnoj datoteci

7.       Na puno mjesta nemate postavljene access modifiere (private, protected�), potrebno je staviti ih na mjesta gdje nedostaju 