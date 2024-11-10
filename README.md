# Pre-interview assignment


## System description
We love lunch, but it's not easy to find the right restaurant each day. A simple tool would be nice to help us select which restaurant to visit. It should be able to add new restaurants with information such as what food they serve (chinese, swedish, pizza etc.), where the restaurant is located, and it's opening hours. A randomising function can be used to select "the restaurant of the day", but make sure we don't get the same one too often!

## Instructions
* Fork this repository
* Make an estimate on how long you think it would take to complete this project and add it to the README
* Use .NET 6 for your system (or later stable version)
* Include instructions on how to run your project in this README
* Spend approximately 4-6 hours on this project
* When you're done, write a little bit about what your next steps would be if you had more time

When you're done, ideally within a week of you seeing this, send us a pull request with your work in it to this repository! Bonus points if your commits are descriptive. =)



Johannes Notes:

- Time estimate: 4-5h.

- How to run project: In main folder, enter "RestaurantApp.Web" Folder. Start solution and run the project with IIS Express (there may be a possibility that RestaurantApp.Web need to be set as "Startup Project").


Sluttiden f�r test tog ca.7-8h. Jag hade f�rst r�knat med att det skulle ta lite mindre tid men d� jag hade en enklare implementation i �tanke.
Hade f�rst inte t�nkt att bygga med det med repository och service men k�nde att det blev mer n�dv�ndigt f�r att h�lla mig n�rmre "verkligheten".
Det blev dock inte att jag la tid p� att k�ra dessa delar i separata projekt utan gjorde det lite enklare med foldrar i .Web proj.
Samt att jag skippade databas utan ist�llet h�ll all data i minnet.

Jag tyckte testet var p� en lagom niv� f�r den f�rv�ntade tiden, stor anledning till att jag �verskred lite i tid var att jag snurrade runt p� Daily Restaurant randomisern.
D� jag inte har kodat p� v�ldigt l�nge blev det en tyngre process att f� fram en implementation som h�ll undan logiken s� mycket som m�jligt fr�n controllern.

Jag hade �nskat att jag hade implementerat b�ttre hantering av null, samt att det try/catch �r helt fr�nvarande i detta projekt.
B�da dessa saker �r jag dock helt �vertygad om att jag kommer tillbaks till fort om jag blir aktiv p� en arbetsplats igen.


Side Note: Det ligger �ven ett testprojekt med i solution. Inget som var f�rv�ntat utan det var endast n�got jag gjorde f�r att det k�ndes kul att koda igen :)
Jag �r ingen expert alls p� tester, men det kan vara nyttigt att �va p�!

// Johannes Nilsson

