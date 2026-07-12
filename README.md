# Todo API - Clean Architecture & CQRS

A simple RESTful Todo API built with **ASP.NET Core (.NET 10)** as a learning project to explore **Clean Architecture**, **CQRS**, and **MediatR**.

The primary goal of this project is to understand how requests flow through the application using MediatR while maintaining a clean separation between application layers.

---

## Project Goals

This project was created to gain practical experience with:

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- MediatR
- Pipeline Behaviors
- FluentValidation
- Global Exception Handling
- Entity Framework Core
- Dependency Injection


---

## Features

- Create Todo
- Retrieve Todo items
- Update Todo
- Delete Todo
- Request validation using FluentValidation
- Centralized exception handling
- SQLite database
- Clean separation of responsibilities

---

## Architecture

The solution follows the principles of **Clean Architecture** by separating concerns into independent layers.

```
Solution
│
├── API
├── Application
├── Domain
└── Infrastructure
```

### API

Responsible for:

- Controllers
- Dependency Injection
- HTTP Pipeline
- OpenAPI
- Exception Middleware

### Application

Contains the application business logic including:

- Commands
- Queries
- Handlers
- Validators
- Pipeline Behaviors
- Interfaces

### Domain

Contains the core domain model.

Current Entity:

- Todo

### Infrastructure

Responsible for:

- Entity Framework Core
- SQLite
- Database Context
- Application interface implementations

---

## CQRS

The project follows the CQRS pattern by separating write operations from read operations.

### Commands

Commands modify application state.

Examples:

- CreateTodoCommand
- UpdateTodoCommand
- DeleteTodoCommand

### Queries

Queries retrieve data without changing application state.

Examples:

- GetTodoByIdQuery
- GetTodosQuery

Each request is processed by its own dedicated MediatR Handler.

---

## Request Flow

```
HTTP Request
      │
      ▼
Controller
      │
      ▼
MediatR
      │
      ▼
Pipeline Behaviors
      │
      ▼
Validation
      │
      ▼
Command / Query Handler
      │
      ▼
IAppDbContext
      │
      ▼
SQLite Database
```

---

## Technologies

- ASP.NET Core (.NET 10)
- C#
- MediatR
- Entity Framework Core
- SQLite
- FluentValidation
- OpenAPI
- Clean Architecture
- CQRS

---

## Validation

Request validation is implemented using **FluentValidation**.

Validation is executed automatically through a custom MediatR Pipeline Behavior before reaching the request handlers.

---

## Exception Handling

Unhandled exceptions are processed through a centralized global exception handler.

The API returns standardized Problem Details responses, providing consistent and predictable error messages.

---

## Database

Database Provider:

- SQLite

ORM:

- Entity Framework Core

The application communicates with the database through the `IAppDbContext` abstraction, allowing the Application layer to remain independent of Infrastructure.

---

## Running the Project

### Prerequisites

- .NET 10 SDK

The API will be available locally after startup.

---

## What I Learned

This project helped me gain practical experience with:

- Structuring applications using Clean Architecture
- Separating reads and writes using CQRS
- Using MediatR to decouple application components
- Building validation pipelines
- Centralizing exception handling
- Working with Entity Framework Core abstractions
- Organizing scalable ASP.NET Core solutions

---

## Future Improvements

Some features intentionally left out to keep the project focused on learning CQRS and MediatR.

Possible future improvements include:

- Authentication & Authorization
- Logging
- Unit Testing
- Integration Testing
- Docker Support
- Pagination
- Filtering & Searching
- API Versioning
- Soft Delete
- Domain Events
- Caching

---

## Contact

If you'd like to connect or discuss software development, feel free to reach out.

- GitHub: https://github.com/jubeirmorad
- LinkedIn: https://www.linkedin.com/in/jubeir-morad-8053b0389
- Email: jubiermorad@gmail.com

---

## License

This project is available for educational purposes.