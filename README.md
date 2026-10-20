Car Insurance

Overview

An ASP.NET MVC web application that calculates monthly car insurance quotes based on personal details, vehicle information, and driving history.

Features

Add and manage customer records.

Calculate monthly insurance quotes.

Apply pricing rules based on age, car details, speeding tickets, DUI history, and coverage type.

View all insurance quotes on the Admin page.

Store data in a SQL Server LocalDB database.

Quote Calculation

Base price: $50 per month.

Age 18 or under: +$100.

Age 19–25: +$50.

Age 26 or older: +$25.

Car made before 2000 or after 2015: +$25.

Porsche: +$25.

Porsche 911 Carrera: an additional $25.

Each speeding ticket: +$10.

DUI history: +25% of the current total.

Full coverage: +50% of the current total.

Technologies

C#

ASP.NET MVC 5

Entity Framework 6

.NET Framework 4.7.2

SQL Server LocalDB

HTML and Razor

How to Run

Clone or download the repository.

Open CarInsurance.sln in Visual Studio.

Restore NuGet packages.

Make sure SQL Server LocalDB is installed.

Build the solution.

Set CarInsurance as the startup project.

Press F5 to run the application.

Database

The application uses Entity Framework Code First and SQL Server LocalDB. The connection is configured in Web.config, and the database is named CarInsuranceDb.

Purpose

This project demonstrates ASP.NET MVC, database integration, CRUD operations, and automatic insurance quote calculations.
