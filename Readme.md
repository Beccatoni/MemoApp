Process of connecting to the database

 ### dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
 ### dotnet add package Microsoft.EntityFrameworkCore.Design

### create the db context then to deal with the database
### use your context in the application 
### dotnet ef migrations add InitialCreate
### dotnet ef database update
