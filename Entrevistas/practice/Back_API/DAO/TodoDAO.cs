namespace Back_API.DAO
{
    using Back_API.Models;
    using Microsoft.EntityFrameworkCore;

    class TodoDAO : DbContext
    {
        public TodoDAO(DbContextOptions<TodoDAO> options): base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
