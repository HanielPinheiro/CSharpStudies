using Back_API.DAO;
using Back_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDAO>(options => options.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", GetAllTodos);
todoItems.MapGet("/complete", GetCompleteTodos);
todoItems.MapGet("/{id}", GetTodo);

todoItems.MapPost("/", CreateTodo);
todoItems.MapPut("/{id}", UpdateTodo);
todoItems.MapDelete("/{id}", DeleteTodo);

app.Run();


static async Task<IResult> GetAllTodos(TodoDAO dao)
{
    return TypedResults.Ok(await dao.Todos.ToArrayAsync());
}
static async Task<IResult> GetCompleteTodos(TodoDAO dao)
{
    return TypedResults.Ok(await dao.Todos.Where(t => t.IsComplete).ToListAsync());
}

static async Task<IResult> GetTodo(int id, TodoDAO dao)
{
    return (await dao.Todos.FindAsync(id)) is Todo todo ? Results.Ok(todo) : Results.NotFound();
}

static async Task<IResult> CreateTodo(Todo todo, TodoDAO dao)
{
    dao.Todos.Add(todo);
    await dao.SaveChangesAsync();
    return TypedResults.Created($"/todoitems/{todo.Id}", todo);
}

static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDAO dao)
{
    Todo? todo = await dao.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await dao.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteTodo(int id, TodoDAO dao)
{
    if (await dao.Todos.FindAsync(id) is Todo todo)
    {
        dao.Todos.Remove(todo);
        await dao.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}