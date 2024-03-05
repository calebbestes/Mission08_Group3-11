
using SQLitePCL;

namespace Mission08_Group3_11.Models
{
    public class EFTaskRepository : ITaskRepository

    {
        private ToDoListContext _context;
        public EFTaskRepository (ToDoListContext temp)
        {
            _context = temp;
        }
        public IQueryable<Application> ToDoList => _context.ToDoList;

        public IQueryable<Category> Categories =>  _context.Categories;

        public void DeleteApplication(Application m)
        {
            _context.Remove(m);
            _context.SaveChanges();
        }
    }
}
