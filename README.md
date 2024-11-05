## About the project
I wanted this project to reflect how I work as a developer, writing clean, structured and reusable code.
I implemented controllers to handle requests, services to handle business logic, 
and repositories to manage data access. This way makes the app more scalable and great for developer experience.

## Estimated Time
Project setup - 1.5h
* Create a project using .net core web api template
* Implement folder strucutre
* Define a restaurant model with given properties
* Register database context, in-memory database, from Entity Framework

Implement backend logic - 2.5
* Create controllers to handle api requests, get all and add new restaurant
* Implement repository for a clean code and manage data access
* Implement controller and service that generates a random restaurant from the db
* Test with swagger

## Instructions to run the project
* Clone the repository locally on your computer
* Navigate and open the project directory
* To make sure all necessary packages are in place, run the command, dotnet restore
* Run the project with the command, dotnet run
* In the browser head to, https://localhost:7283/swagger/index.html
* Document apis using swagger

## Next steps
If I had more time, my next steps would be to implement a persistant database,
implement a error handler to generate friendly error messages and integrate a frontend client for a fun experience!

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
