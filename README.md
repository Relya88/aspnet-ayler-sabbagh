# ASP.NET Gym Portal

A gym web application built with ASP.NET Core MVC following Clean Architecture.

## Features
- User registration and login (ASP.NET Identity)
- User account management (CRUD)
- Membership system (backend)
- Entity Framework Core (Code First + Migrations)

## Tech Stack
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Clean Architecture

## Run locally
1. Clone the repo
2. Run:
   dotnet ef database update --project Infrastructure --startup-project Presentation.WebApp
3. Start:
   dotnet run --project Presentation.WebApp
