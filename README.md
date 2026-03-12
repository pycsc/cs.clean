# Todo API — C# Clean Architecture

A RESTful To-Do list API built with C# and ASP.NET Core, following Clean
Architecture principles with an in-memory database.

## Architecture

```
TodoApp/
├── TodoApp.Domain/          Entities + Repository interface
├── TodoApp.Application/     Business logic (TodoService)
├── TodoApp.Infrastructure/  In-memory repository
├── TodoApp.Api/             HTTP controllers
└── TodoApp.Tests/           Unit and functional tests
```

Each layer has a single responsibility:

| Layer | Responsibility |
|---|---|
| `TodoApp.Domain/` | Pure domain model (`Todo`) |
| `TodoApp.Application/` | Repository contract + business logic |
| `TodoApp.Infrastructure/` | In-memory repository |
| `TodoApp.Api/` | HTTP controllers |

## API Endpoints

| Method | Endpoint | Description | Status |
|---|---|---|---|
| GET | /todos | List all todos | 200 |
| POST | /todos | Create a todo | 201 |
| GET | /todos/{id} | Get by ID | 200 |
| PUT | /todos/{id} | Update a todo | 200 |
| DELETE | /todos/{id} | Delete a todo | 204 |

## Todo Object

```json
{
  "id": 1,
  "title": "Buy groceries",
  "isCompleted": false,
  "createdAt": "2026-03-12T11:00:00Z"
}
```

## Requirements

- .NET 8+

## Setup & Run

```bash
cd TodoApp/TodoApp.Api
dotnet run
```

Server runs on `http://localhost:8080`.

## Testing

```bash
# Unit and functional tests
dotnet test TodoApp.sln
```
