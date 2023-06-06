# Data Table App
Assignment to create a data table app with a .NET back-end, Angular front-end using PrimeNG. Task is to create a user data table and display it on the web with CRUD operations, sorting and filtering.

# DataTable.DAL
Data access layer of the app representented by a class library C# project. Uses EF Core code-first approach using User entity to create a database with MSSQL. Implemented generic repository pattern for data access, by having GenericRepository.cs with basic CRUD operations, UserRepository.cs inherits from GenericRepository.cs and implements custom methods for filtering and sorting.

# DataTable.BLL
Business logic layer representented by a class library. Accesses the repository to Query, Insert, Update, Delete data, all logical operations are done there, before or after data is taken from repository. Does not have access to Database Context, rather it uses only the repository for data. UserService.cs represent the logic class for the User entity/table.

# DataTable.WEB
ASP.NET Core Web API project, calling the business logic after receiving Request and sending Responses from/to the client. Uses Swagger for documenting API endpoints and testing. Communicates only with BLL project directly and doesn't have access to any Data Access. Controllers represent API endpoints, Models uses different models for requesting users and for giving a response with them, uses AutoMapper to map them between requesting/responding and the entity class.

# DataTable.Test
Test Project Library that consists of unit tests made with xUnit and Moq libraries. Test methods of the UserService class/BLL

# Angular/Front-End
Front-end project that makes calls to the API and provides a user interface for data table where you can list all users and filter or sort them with the provided options and perform CRUD operations. Used Angular as a front-end framework and PrimeNG for most UI components.

# Project Startup:
1. Configure connection string by changing the default connection in appsettings.json file in DataTable.WEB.
2. In the package manager console run "Update-Database" to create the database in the local machine(Port: 5001).
3. Setup DataTable.WEB as the startup project and run it in Visual Studio(It will open a browser window with Swagger).
4. in Angular-Frontend > data-table open a cmd and run "ng serve/npm start" command(Should be listening on port 4200).
5. In the browser(while both client and API are still running) open http://localhost:4200/ and you will be able to use the app.
