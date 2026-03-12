/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoServiceTests.cs                                   +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2026/03/12 12:49:17 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TodoApp.Application.Services;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;
using Xunit;
using FluentAssertions;

namespace TodoApp.Tests;

public class TodoServiceTests
{
    private readonly Mock<ITodoRepository> _repo;
    private readonly TodoService _svc;

    public TodoServiceTests()
    {
        _repo = new Mock<ITodoRepository>();
        _svc  = new TodoService(_repo.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllTodos()
    {
        var list = new List<TodoItem>
        {
            new() { Id = 1, Title = "A" },
            new() { Id = 2, Title = "B" },
        };
        _repo.Setup(r => r.GetAllAsync()).ReturnsAsync(list);
        var result = await _svc.GetAllAsync();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsTodo()
    {
        var item = new TodoItem { Id = 1, Title = "Test" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(item);
        var result = await _svc.GetByIdAsync(1);
        result.Should().BeEquivalentTo(item);
    }

    [Fact]
    public async Task AddAsync_ReturnsCreatedItem()
    {
        _repo.Setup(r => r.AddAsync(It.IsAny<TodoItem>()))
             .Returns(Task.CompletedTask);
        var result = await _svc.AddAsync("New Task");
        result.Should().NotBeNull();
        result.Title.Should().Be("New Task");
        _repo.Verify(
            r => r.AddAsync(It.Is<TodoItem>(t => t.Title == "New Task")),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ModifiesTodo()
    {
        var item = new TodoItem { Id = 1, Title = "Old" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(item);
        var result = await _svc.UpdateAsync(1, "New", true);
        result.Should().NotBeNull();
        result!.Title.Should().Be("New");
        result.IsCompleted.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_ReturnsTrueWhenFound()
    {
        var item = new TodoItem { Id = 1, Title = "A" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(item);
        var ok = await _svc.DeleteAsync(1);
        ok.Should().BeTrue();
        _repo.Verify(r => r.DeleteAsync(1), Times.Once);
    }
}
