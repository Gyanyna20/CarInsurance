# CarInsurance MVC 5 project

This is a classic ASP.NET MVC 5 project targeting .NET Framework 4.7.2.

## Open and run
1. Extract the ZIP to a normal writable folder.
2. Open `CarInsurance.sln` in Visual Studio (not the `.csproj` as a file).
3. Ensure Visual Studio has the **ASP.NET and web development** workload and the **.NET Framework 4.7.2 targeting pack** installed.
4. Right-click the `CarInsurance` project and choose **Restore NuGet Packages** if prompted.
5. Build with **Build > Build Solution**.
6. Right-click `CarInsurance` > **Set as Startup Project**, then press F5.

## Database
The app uses Entity Framework 6 Code First and LocalDB:
`(LocalDB)\MSSQLLocalDB`, database `CarInsuranceDb`.
The first database access should create the database and `Insurees` table automatically. Make sure SQL Server Express LocalDB is installed. If your class assignment specifically requires a physical `.mdf` and `.ldf` file to submit, locate the generated database in SQL Server Object Explorer and use its properties / SQL Server tooling to determine its files.

## Notes
- The `Quote` is calculated by the controller and is not entered by the user.
- The Admin page lists first name, last name, email address, and quote.
- This project cannot install Visual Studio workloads or LocalDB automatically; those are machine prerequisites.
