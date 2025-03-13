/* ************************************************************************** */
/*                                                                            */
/*                                                           +#               */
/*    Program.cs                                            +##               */
/*                                                        +###+               */
/*    By: lucas <lucas@tsiaraso.com>                   +########+             */
/*                                                         +###+              */
/*    Created: 2025/03/13 02:22:44 by lucas                  ##+              */
/*    Updated: 2025/03/13 02:22:44 by lucas                  #+               */
/*                                                                            */
/* ************************************************************************** */

using TodoApp.Application.Services;
using TodoApp.Domain.Interfaces;
using TodoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<TodoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
