# NovenaTracker - Architecture Documentation

## Overview
A .NET MAUI Android application displaying Catholic novenas, built with EF Core, DDD principles, and CQRS to separate presentation and business logic.

## Architecture

The project follows Domain-Driven Design (DDD) principles with clear separation of concerns across multiple layers:

### Project Structure

```
NovenaTracker/
├── NovenaTracker.Domain/           # Domain Layer
│   ├── Entities/                   # Domain entities
│   │   ├── Novena.cs
│   │   ├── NovenaDayPrayer.cs
│   │   └── NovenaCompletion.cs
│   └── Interfaces/
│       └── IDbQuery.cs             # Query abstraction
│
├── NovenaTracker.Model/            # Models & CQRS Contracts
│   ├── Commands/                   # CQRS Commands
│   │   └── CreateNovenaCommand.cs
│   └── Queries/                    # CQRS Queries & DTOs
│       ├── GetNovenaByIdQuery.cs
│       ├── GetAllNovenasQuery.cs
│       └── GetNovenaPrayersForDayQuery.cs
│
├── NovenaTracker.ApplicationLayer/ # Application Layer (CQRS Handlers)
│   └── Handlers/
│       └── QueryHandlers/          # Query handlers using IAsyncQueryHandler
│           ├── GetNovenaByIdQueryHandler.cs
│           ├── GetAllNovenasQueryHandler.cs
│           └── GetNovenaPrayersForDayQueryHandler.cs
│
├── NovenaTracker.Infrastructure/   # Infrastructure Layer
│   ├── Data/                       # EF Core DbContext
│   │   ├── NovenaTrackerDbContext.cs
│   │   └── NovenaTrackerDbContextFactory.cs
│   ├── DbConfiguration/            # EF Core Entity Configurations
│   │   ├── NovenaConfiguration.cs
│   │   ├── NovenaDayPrayerConfiguration.cs
│   │   └── NovenaCompletionConfiguration.cs
│   ├── Queries/
│   │   ├── DbQuery.cs              # IDbQuery implementation
│   │   └── NovenaDbQuery.cs        # Query logic for Novena data
│   └── Migrations/                 # EF Core migrations
│
└── NovenaTracker.Configuration/    # Dependency Injection Configuration
    └── Extensions/
        └── ServiceCollectionExtensions.cs
```

## Domain Entities

### Novena
Represents a novena (nine-day prayer) with:
- Id, Title, Description
- DaysDuration (typically 9)
- CreatedDate
- Navigation properties to DayPrayers and Completions

### NovenaDayPrayer
Represents prayers for each day of a novena:
- Id, NovenaId, DayNumber
- PrayerTitle, PrayerText
- Relationship to Novena

### NovenaCompletion
Tracks completion status of each day:
- Id, NovenaId, DayNumber
- IsCompleted, CompletedDate
- CreatedDate
- Unique constraint on (NovenaId, DayNumber)

## CQRS Implementation

The project uses SimpleCqrs (v0.1.3) for implementing CQRS pattern:

### Query Flow
1. **Query Definition** (Model layer): Define IQuery<TResult>
2. **Query Logic** (Infrastructure layer): NovenaDbQuery contains business logic
3. **Query Handler** (ApplicationLayer): IAsyncQueryHandler delegates to NovenaDbQuery
4. **Execution**: Use ISimpleMediator to send queries

### Example Query Usage

```csharp
// In your service or controller
public class NovenaService
{
    private readonly ISimpleMediator _mediator;

    public NovenaService(ISimpleMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<NovenaDto?> GetNovenaAsync(int id)
    {
        var query = new GetNovenaByIdQuery { Id = id };
        return await _mediator.SendAsync(query);
    }
}
```

## Entity Framework Core

### Database Provider
- **SQLite** for local Android storage
- Connection string: `Data Source=novenatracker.db`

### Configuration Approach
Entity configurations are separated into `IEntityTypeConfiguration<T>` classes in the `DbConfiguration` namespace:

```csharp
// Example: NovenaConfiguration.cs
public class NovenaConfiguration : IEntityTypeConfiguration<Novena>
{
    public void Configure(EntityTypeBuilder<Novena> builder)
    {
        // Configure properties, relationships, indexes
        // Include seed data
    }
}
```

### Migrations

Create migration:
```bash
cd NovenaTracker.Infrastructure
dotnet ef migrations add MigrationName
```

Update database:
```bash
dotnet ef database update
```

## Dependency Injection Setup

### Basic Setup
```csharp
using NovenaTracker.Configuration.Extensions;

// In your Program.cs or Startup.cs
services.ConfigureNovenaTrackerWithSqlite(
    connectionString: "Data Source=novenatracker.db"
);
```

### What Gets Registered
- `NovenaTrackerDbContext` (Scoped)
- `IDbQuery` → `DbQuery` (Scoped)
- `NovenaDbQuery` (Scoped)
- All CQRS handlers from ApplicationLayer assembly (automatically discovered)

## Key Design Decisions

### 1. IAsyncQueryHandler over IQueryHandler
All query handlers use `IAsyncQueryHandler<TQuery, TResult>` for async operations:
```csharp
public class GetNovenaByIdQueryHandler : IAsyncQueryHandler<GetNovenaByIdQuery, NovenaDto?>
{
    public async Task<NovenaDto?> HandleAsync(GetNovenaByIdQuery query, CancellationToken cancellationToken)
    {
        // Implementation
    }
}
```

### 2. NovenaDbQuery Separation
Query logic is extracted into `NovenaDbQuery` class:
- **Benefits**: Testability, reusability, single responsibility
- **Pattern**: Handlers delegate to query classes

### 3. Entity Configuration Classes
Using `IEntityTypeConfiguration<T>` instead of Fluent API in OnModelCreating:
- **Benefits**: Separation of concerns, maintainability
- **Location**: `Infrastructure/DbConfiguration/`

### 4. Seed Data
Initial sample data is included in entity configurations:
- 1 sample Novena
- 3 sample day prayers
- Ready for testing and demonstration

## Technologies

- **.NET 10.0**
- **Entity Framework Core 10.0.0**
- **SQLite** (Microsoft.EntityFrameworkCore.Sqlite 10.0.0)
- **SimpleCqrs 0.1.3** (CQRS implementation)
- **C# 13** with nullable reference types enabled

## Next Steps

1. Create MAUI Android UI project
2. Implement command handlers for creating/updating data
3. Add authentication and user management
4. Implement progress tracking features
5. Add notification system for daily prayers
6. Localization support

## License

See LICENSE file for details.
