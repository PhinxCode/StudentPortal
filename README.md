# Student Portal - Setup Guide

## Prerequisites

Make sure you have the following installed:

- .NET SDK (7.0 or later)
- SQL Server (or a compatible database)
- Entity Framework Core tools

---

## Step 1: Configure the database connection

1. Open the `appsettings.json` file.
2. Locate the `ConnectionStrings` section and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=StudentPortalDb;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;Trusted_Connection=False;TrustServerCertificate=True;"
}
```

---

# Apply existing migrations

dotnet ef migrations add <MigrationName>

dotnet ef database update
