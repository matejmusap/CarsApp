"# CarsApp"

This is CarsApp. Aplication where you can create list of car models with aditional info about them.
To run this app you need to have set up enviroment for .NET Core framework. 
You also need to install Nu Get packages:
 - cloudsribe.Pagination.Models
 - cloudscribs.Web.Pagination
 - Microsoft.EntityFrameworkCore.SqlServer.
 Then in terminal you need to run commands:
 - Add-Migration InitialCreate
 - Update-Database
 This will initialize you database and define context.
 Start app with CRTL + F5 to start app without debbuging.
 SeedData file should add 15 car models in database for initial testing.
