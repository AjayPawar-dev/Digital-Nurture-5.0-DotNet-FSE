# Lab 3: Creating and Applying Migrations in Entity Framework Core

## Scenario

In a Retail Inventory Management System, entity classes alone are not enough to create database tables. Entity Framework Core uses migrations to convert entity classes into database structures.

In this lab, I used Entity Framework Core Migrations to generate the database schema from the Product and Category entity classes and apply the changes to the database.

## Understanding Migrations

A migration is a feature of Entity Framework Core that keeps the database schema synchronized with the application's entity classes.

Instead of manually creating tables in SQL Server, migrations automatically generate the required database structure based on the C# entity classes.

### Benefits of Migrations

* Automates database creation and updates.
* Tracks database schema changes over time.
* Eliminates the need to manually write SQL scripts.
* Maintains consistency between the application and the database.

## Implementation Steps

### Step 1: Install EF Core CLI Tool

The Entity Framework Core command-line tool was installed using:

```powershell
dotnet tool install --global dotnet-ef
```

### Step 2: Create Initial Migration

A migration named InitialCreate was generated using:

```powershell
dotnet ef migrations add InitialCreate
```

This command analyzed the Product and Category entity classes and generated migration files automatically.

### Step 3: Apply Migration to Database

The generated migration was applied using:

```powershell
dotnet ef database update
```

This command created the database and the required tables.

## Generated Migration Files

Entity Framework Core automatically created a Migrations folder containing:

* InitialCreate.cs
* InitialCreate.Designer.cs
* AppDbContextModelSnapshot.cs

These files contain instructions required to create and manage the database schema.

## Output

Look at the screenshot below:

![Lab 3 Output](Screenshots/lab3_output.png)

The screenshot shows:

* Successful installation of the Entity Framework Core CLI tool.
* Successful execution of the migration creation command.
* Successful execution of the database update command.
* Automatic creation of the Migrations folder.
* Updated project structure visible in Solution Explorer.

## Result

Thus, Entity Framework Core Migrations were successfully created and applied to the database. The database schema was generated automatically from the entity classes, demonstrating the Code First approach in Entity Framework Core.
