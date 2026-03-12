/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoApiTests.cs                                       +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2026/03/12 12:49:17 by lucas                  ##+              */
/*    Updated: 2026/03/12 12:49:17 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoApp.Domain.Entities;
using Xunit;
using FluentAssertions;

namespace TodoApp.Tests;

public class TodoApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TodoApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTodos_ReturnsEmptyList()
    {
        var res = await _client.GetAsync("/todos");
        res.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await res.Content.ReadFromJsonAsync<List<TodoItem>>();
        body.Should().BeEmpty();
    }

    [Fact]
    public async Task CreateTodo_Returns201WithItem()
    {
        var res = await _client.PostAsJsonAsync("/todos", "Test Todo");
        res.StatusCode.Should().Be(HttpStatusCode.Created);
        var item = await res.Content.ReadFromJsonAsync<TodoItem>();
        item.Should().NotBeNull();
        item!.Title.Should().Be("Test Todo");
        item.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public async Task GetTodoById_Returns404ForMissing()
    {
        var res = await _client.GetAsync("/todos/999");
        res.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateTodo_ReturnsUpdatedItem()
    {
        await _client.PostAsJsonAsync("/todos", "Original");
        var update = new TodoItem { Title = "Updated", IsCompleted = true };
        var res = await _client.PutAsJsonAsync("/todos/1", update);
        res.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await res.Content.ReadFromJsonAsync<TodoItem>();
        body!.Title.Should().Be("Updated");
    }

    [Fact]
    public async Task DeleteTodo_Returns404ForMissing()
    {
        var res = await _client.DeleteAsync("/todos/999");
        res.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
