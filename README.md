# SiaInteractive.CControl.Challenge

## Overview
SiaInteractive.CControl.Challenge is a RESTful API built using Microsoft .NET 9, following clean architecture principles. The API provides functionalities to manage users, including CRUD operations and authentication features such as login and logout.

## Project Structure
The project is organized into several layers:

- **Api**: Contains the controllers and the entry point for the application.
- **Application**: Contains the business logic, services, and data transfer objects (DTOs).
- **Domain**: Contains the core entities and interfaces for data access.
- **Infrastructure**: Contains the data access implementation, logging configuration, and migrations.
- **Tests**: Contains unit tests for the API, application services, and infrastructure components.

## Technologies Used
- .NET 9
- Entity Framework 9
- SQL Server Express
- Serilog for logging
- Swagger for API documentation

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd SiaInteractive.CControl.Challenge
   ```
3. Restore the NuGet packages:
   ```
   dotnet restore
   ```
4. Update the connection string in `SiaInteractive.CControl.Challenge.Api/appsettings.json` to point to your SQL Server Express instance.
5. Run the migrations to set up the database:
   ```
   dotnet ef database update --project SiaInteractive.CControl.Challenge.Infrastructure
   ```
6. Start the API:
   ```
   dotnet run --project SiaInteractive.CControl.Challenge.Api
   ```

## Usage
- The API provides endpoints for managing users, including:
  - **Create User**: POST /api/users
  - **Get User**: GET /api/users/{id}
  - **Update User**: PUT /api/users/{id}
  - **Delete User**: DELETE /api/users/{id}
  - **Login**: POST /api/users/login
  - **Logout**: POST /api/users/logout

## API Documentation
Swagger documentation is available at `/swagger` once the API is running. This provides detailed information about each endpoint, including request and response formats.

## Logging
Serilog is configured for logging application events. Logs can be found in the specified output location in the `appsettings.json` file.

## Testing
Unit tests are included for the API controllers, application services, and infrastructure components. To run the tests, use:
```
dotnet test
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.