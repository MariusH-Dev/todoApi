using Microsoft.EntityFrameworkCore;

namespace TodoAPI
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
