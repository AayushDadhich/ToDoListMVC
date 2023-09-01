# To-Do Task List Application

Welcome to the To-Do Task List application built on ASP.NET Core MVC! This application allows users to manage their tasks efficiently. Users can register, log in, and perform CRUD (Create, Read, Update, Delete) operations on their to-do tasks. It also utilizes JWT (JSON Web Tokens) for authentication and authorization using custom attributes, SQL databases for data storage, and Unity Dependency Injection container for managing dependencies.

## Features

- User Registration and Authentication: Users can create an account, log in, and log out securely using JWT token-based authentication.
- To-Do Task Management: Users can add, view, edit, and delete their to-do tasks.
- Repository Pattern: The application follows the repository pattern for data access, ensuring separation of concerns.
- Unity Dependency Injection: Unity DI container is used for handling dependency injection to achieve loose coupling and maintainability.
- Default Users Created: For your convenience, we've created a default user:
  - Email: aayush@gmail.com
  - Password: password

## Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET Core SDK installed (version X.X.X)
- SQL Server or SQL Server LocalDB installed
- Git for cloning the repository
- Your favorite code editor (e.g., Visual Studio, Visual Studio Code)

## Getting Started

To run this application locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ToDoTaskList.git

2. Open the web.config file in your ASP.NET Core MVC project.

3. Locate the <connectionStrings> section and add your connection string as follows:
  ```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="your_connection_string_here" providerName="System.Data.SqlClient" />
</connectionStrings>
```

4. Replace "your_connection_string_here" with your actual SQL Server connection string.

5. Save the web.config file.

6. Open the Package Manager Console in Visual Studio.

7. Run the following command to apply the database migrations:
  ```bash
  Update-Database
 ```
  This command will create or update the database schema based on your application's DbContext and the migrations you've defined.

8. Build your project:
  ```bash
  dotnet build
  ```

9. Finally, run your ASP.NET Core MVC application:
  ```bash
  dotnet run
  ```

Your application should now be up and running with the updated database configuration.
