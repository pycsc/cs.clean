# Todo API — C# Clean Architecture

A RESTful To-Do list API built with C# and ASP.NET Core,
following Clean Architecture.

## Architecture

```
TodoApp/
├── TodoApp.Domain/          Entities + Repository interface
├── TodoApp.Application/     Business logic (TodoService)
├── TodoApp.Infrastructure/  In-memory repository
└── TodoApp.Api/             HTTP controllers
```

## API Endpoints

| Method | Endpoint     | Description    |
|--------|--------------|----------------|
| GET    | /todos       | List all todos |
| POST   | /todos       | Create a todo  |
| GET    | /todos/{id}  | Get by ID      |
| PUT    | /todos/{id}  | Update a todo  |
| DELETE | /todos/{id}  | Delete a todo  |

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

Configure port in `TodoApp/TodoApp.Api/Properties/launchSettings.json`
or set `ASPNETCORE_URLS=http://localhost:8080`.
