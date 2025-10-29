using Back_API.DAO;
using Back_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDAO>(options => options.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
app.MapGet("/todoitems", async (TodoDAO inMemoryDao) => await inMemoryDao.Todos.ToListAsync());
app.MapGet("/todoitems/complete", async (TodoDAO db) => await db.Todos.Where(t => t.IsComplete).ToListAsync());
app.MapGet("/todoitems/{id}", async (int id, TodoDAO inMemoryDao) => ( await inMemoryDao.Todos.FindAsync(id) ) is Todo todo ? Results.Ok(todo) : Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, TodoDAO dao) =>
{
    dao.Todos.Add(todo);
    await dao.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDAO inMemoryDAO) =>
{
    Todo? todo = await inMemoryDAO.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await inMemoryDAO.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoDAO inMemoryDao) =>
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
