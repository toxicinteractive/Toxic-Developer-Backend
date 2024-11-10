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


Sluttiden för test tog ca.7-8h. Jag hade först räknat med att det skulle ta lite mindre tid men då jag hade en enklare implementation i åtanke.
Hade först inte tänkt att bygga med det med repository och service men kände att det blev mer nödvändigt för att hålla mig närmre "verkligheten".
Det blev dock inte att jag la tid på att köra dessa delar i separata projekt utan gjorde det lite enklare med foldrar i .Web proj.
Samt att jag skippade databas utan istället höll all data i minnet.

Jag tyckte testet var på en lagom nivå för den förväntade tiden, stor anledning till att jag överskred lite i tid var att jag snurrade runt på Daily Restaurant randomisern.
Då jag inte har kodat på väldigt länge blev det en tyngre process att få fram en implementation som höll undan logiken så mycket som möjligt från controllern.

Jag hade önskat att jag hade implementerat bättre hantering av null, samt att det try/catch är helt frånvarande i detta projekt.
Båda dessa saker är jag dock helt övertygad om att jag kommer tillbaks till fort om jag blir aktiv på en arbetsplats igen.


Side Note: Det ligger även ett testprojekt med i solution. Inget som var förväntat utan det var endast något jag gjorde för att det kändes kul att koda igen :)
Jag är ingen expert alls på tester, men det kan vara nyttigt att öva på!

// Johannes Nilsson

