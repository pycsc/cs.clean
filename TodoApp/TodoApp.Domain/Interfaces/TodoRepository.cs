/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoRepository.cs                                     +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2025/03/13 02:22:44 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task AddAsync(TodoItem item);
    Task UpdateAsync(TodoItem item);
    Task DeleteAsync(int id);
}
