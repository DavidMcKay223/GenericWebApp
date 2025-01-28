# How to do DB Migrations in Entity Framework
Go to Tools => NuGet Package Manager => Package Manager Console

## Initial Migration
```
Add-Migration -Name InitialCreate -Context TemplateContext
```

## Update Migration
```
Add-Migration YourMigrationName -Context TemplateContext
```

## Update Database
```
Update-Database -Context TemplateContext
```
