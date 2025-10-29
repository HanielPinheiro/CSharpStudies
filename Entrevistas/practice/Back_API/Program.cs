using Back_API.DAO;
using Back_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDAO>(options => options.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", async (TodoDAO inMemoryDao) => await inMemoryDao.Todos.ToListAsync());
todoItems.MapGet("/complete", async (TodoDAO db) => await db.Todos.Where(t => t.IsComplete).ToListAsync());
todoItems.MapGet("/{id}", async (int id, TodoDAO inMemoryDao) => ( await inMemoryDao.Todos.FindAsync(id) ) is Todo todo ? Results.Ok(todo) : Results.NotFound());

todoItems.MapPost("/", async (Todo todo, TodoDAO dao) =>
{
    dao.Todos.Add(todo);
    await dao.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDAO inMemoryDAO) =>
{
    Todo? todo = await inMemoryDAO.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await inMemoryDAO.SaveChangesAsync();

    return Results.NoContent();
});

todoItems.MapDelete("/{id}", async (int id, TodoDAO inMemoryDao) =>
{
    if (await inMemoryDao.Todos.FindAsync(id) is Todo todo)
    {
        inMemoryDao.Todos.Remove(todo);
        await inMemoryDao.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
