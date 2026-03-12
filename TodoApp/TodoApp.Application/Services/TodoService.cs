/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoService.cs                                        +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2026/03/12 12:37:41 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

﻿using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Services;

public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TodoItem>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<TodoItem?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<TodoItem> AddAsync(string title)
    {
        var item = new TodoItem { Title = title };
        await _repository.AddAsync(item);
        return item;
    }

    public async Task<TodoItem?> UpdateAsync(
        int id, string title, bool isCompleted)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return null;
        item.Title = title;
        item.IsCompleted = isCompleted;
        await _repository.UpdateAsync(item);
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}
