using Microsoft.EntityFrameworkCore;

namespace Mission08_Group3_11.Models
{
    public class ToDoListContext: DbContext

    {
       public ToDoListContext(DbContextOptions<ToDoListContext>options) : base (options) 
        {
        }

        public DbSet<Application> ToDoList { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
