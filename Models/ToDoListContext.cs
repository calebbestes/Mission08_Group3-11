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

        protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data
        {
            modelBuilder.Entity<Category>().HasData(

               new Category { CategoryId = 1, CategoryName = "Home" },
               new Category { CategoryId = 2, CategoryName = "School" },
               new Category { CategoryId = 3, CategoryName = "Work" },
               new Category { CategoryId = 4, CategoryName = "Church" }
               );
        }

    }
}
