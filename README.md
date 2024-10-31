# DubRep

DubRep is a .NET 8 Web API application designed to serve as a repository for dubbing information. It stores and manages data for voice actors, series, and roles, leveraging Entity Framework Core and ASP.NET Core. The project models the relationships between these entities, allowing users to manage and retrieve information on dubbing roles in various series.

## Features

- **Models**: 
  - *Voice Actors*: Contains information on individual voice actors.
  - *Series*: Stores data on various dubbed series.
  - *Roles*: Links voice actors to specific characters within a series.

- **DTOs**:
  - For each model, both Add and Update DTOs are implemented to facilitate controlled data transfer.

- **API Controllers**:
  - Provides RESTful endpoints for managing each model, built with ASP.NET Core 8 API controllers.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- SQL Server
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended for development)

## Installation

1. **Clone the repository and open in Visual Studio**:
   ```bash
   git clone https://github.com/idan-sh1/DubRep.git

   Open the project in [Visual Studio](https://visualstudio.microsoft.com/), preferably with the .NET 8 SDK installed.

2. **Configure Database**:
   - Open `appsettings.json` and configure the SQL Server connection string under `ConnectionStrings:DefaultConnection`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server_name;Database=DubRepDB;User Id=your_user_id;Password=your_password;"
     }
     ```

3. **Database Initialization**:
   - Run database migrations to set up the database:
     ```bash
     dotnet ef database update
     ```

4. **Start the Application**:
   - In Visual Studio, select **Run** or press `F5`.

## Usage

Use the following endpoints to interact with the DubRep API:

- **Voice Actors**: `/api/voice-actors`
- **Series**: `/api/series`
- **Roles**: `/api/roles`

Each endpoint supports CRUD operations through HTTP requests.

## License

This project is licensed under the MIT License. See `LICENSE` for details.
