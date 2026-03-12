/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoController.cs                                     +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2026/03/12 12:37:41 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;
using TodoApp.Domain.Entities;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoItem>>> Get()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem?>> Get(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item != null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string title)
    {
        var item = await _service.AddAsync(title);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TodoItem item)
    {
        var updated = await _service.UpdateAsync(id, item.Title, item.IsCompleted);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
