# ORMPratice

Simple .NET 10 console project demonstrating Entity Framework Core usage with models for `Student` and `Group` and a `DbContext` implementation.

## Project layout
- `Program.cs` — app entry; creates `UniversityDb` and checks DB connection.
- `Contexts/UniversityDb.cs` — EF Core `DbContext`. Currently contains an inline connection string.
- `Entities/Student.cs` — `Student` entity.
- `Entities/Group.cs` — `Group` entity.

## Requirements
- .NET 10 SDK
- EF Core packages used by the project (check `*.csproj`): at minimum `Microsoft.EntityFrameworkCore` and provider `Microsoft.EntityFrameworkCore.SqlServer`.
- (Optional) `dotnet-ef` global tool for migrations: `dotnet tool install --global dotnet-ef`

## Quick setup
1. Restore and build:
   - dotnet restore
   - dotnet build

2. Configure the database connection:
   - `Contexts/UniversityDb.cs` currently contains an inline connection string:
     `Data Source=JUPITER06\MAIN;Database=University;Integrated Security=True;...`
   - Recommended: move the connection string to `appsettings.json` or use an environment variable and update `UniversityDb` to load it (for production and git safety).

3. Create and apply migrations (if you need to create schema from the model):
   - Add migration:
     - `dotnet ef migrations add InitialCreate`
   - Apply migration:
     - `dotnet ef database update`
   - Note: `Program.cs` includes a commented `context.Database.Migrate();` line — you can enable it to apply migrations at runtime.

4. Run the app:
   - `dotnet run`
   - The app only checks DB connectivity and prints success/failure.

## Entities overview
- `Student`
  - `Id`, `Name`, `Surname`, `Email`, `BirthDate`, `GroupId`, `Group` (navigation)
- `Group`
  - `Id`, `Name`, `Limit`, `Students` (collection navigation)

## Notes & recommendations
- Do not keep production connection strings in source control. Prefer `appsettings.json` (excluded from git if needed), user secrets, or environment variables.
- Consider making `UniversityDb` accept `DbContextOptions<UniversityDb>` and register it with DI for flexibility and easier testing.
- Add `Microsoft.EntityFrameworkCore.Design` to the project if you use migrations.
- If you need help migrating the inline connection string to configuration, tell me and I can provide the exact code changes.
