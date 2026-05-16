# CommsFlow2

A simple ASP.NET Core Web API for managing templates. This project lets you create and list templates using a SQLite database. It includes basic endpoints and Swagger UI for easy testing.

## Features

- List all templates
- Add new templates
- Simple SQLite database integration
- Swagger UI for API documentation

## How to Run

1. Install .NET 8 or later.
2. Install required NuGet packages:
   ```sh
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Swashbuckle.AspNetCore
   ```
3. Install EF Core tools (if not already installed):
   ```sh
   dotnet tool install --global dotnet-ef
   ```
4. Restore all dependencies:
   ```sh
   dotnet restore
   ```
5. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
6. Start the API:
   ```sh
   dotnet run
   ```

## Docker

To build and run the app in Docker:

+1. Build the Docker image:

```sh
docker build -t commsflow .
```

2. Run the container:
   ```sh
   docker run -p 5275:5275 commsflow
   ```

Or use Docker Compose:

```sh
docker-compose up --build
```

The API will be available at `http://localhost:5275/swagger`. 7. Open your browser at `http://localhost:5275/swagger` to test the endpoints.

---

This project is a good starting point for learning how APIs work with .NET and Entity Framework Core.
