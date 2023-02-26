[![.NET](https://github.com/canyener/rideshare/actions/workflows/dotnet.yml/badge.svg)](https://github.com/canyener/rideshare/actions/workflows/dotnet.yml)

# rideshare

A simple clean architecture implementation for Ride Share API.

## TL;DR;
- Be sure to set RAM to 7GBs for docker, apparently 6 causes problems with mssql 2022 (T_T).
- API documentation is handled by swagger, simply visit `/swagger/index.html`. 
- ValueObject implementation is directly from [Microsoft Official Documentation](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects)
- No retry policies for database connection implemented intentionally due to time limit.
- Commit emoji's from [Gitmoji commit extension](https://github.com/benjaminadk/emojigit) (Credits to [Benjamin](https://github.com/benjaminadk))
- Architectural tests are written with [NetArchTest](https://github.com/BenMorris/NetArchTest) API. (Credits to [BenMorris](https://github.com/BenMorris)).
- Clean Architecture approach is heavily inspired by [Jason Taylor](https://github.com/jasontaylordev).

## Tech Stack
- .NET 6
- Asp.Net Web API
- Docker
- Microsoft Sql Server
- Entity Framework Core
- Clean Architecture
- CQRS
- NLayer Hexagonal Architecture (Core, Application, Infrastructure and Presentation Layers)
- Very simplistic Domain Driven Design (No aggregates, no domain events, no specification pattern due to time limit)