# ASP.NET Demo Apps
Demo apps built with ASP.NET, used for teaching web programming. Showcasing builting MVC/WEB apps and APIs with ASP.NET.

# DataTable.DAL
Data access layer of the app representented by a class library C# project. Uses EF Core code-first approach using User entity to create a database with MSSQL. Implemented generic repository pattern for data access, by having GenericRepository.cs with basic CRUD operations, UserRepository.cs inherits from GenericRepository.cs and implements custom methods for filtering and sorting.

# DataTable.BLL
Business logic layer representented by a class library. Accesses the repository to Query, Insert, Update, Delete data, all logical operations are done there, before or after data is taken from repository. Does not have access to Database Context, rather it uses only the repository for data. UserService.cs represent the logic class for the User entity/table.

# DataTable.WEB
ASP.NET Core Web API project, calling the business logic after receiving Request and sending Responses from/to the client. Uses Swagger for documenting API endpoints and testing. Communicates only with BLL project directly and doesn't have access to any Data Access. Controllers represent API endpoints, Models uses different models for requesting users and for giving a response with them, uses AutoMapper to map them between requesting/responding and the entity class.
