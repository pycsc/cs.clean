/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    TodoItem.cs                                           +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2026/03/12 12:37:41 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using System;

namespace TodoApp.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
