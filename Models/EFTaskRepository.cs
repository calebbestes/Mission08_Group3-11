namespace Mission08_Group3_11.Models
{
    public class EFTaskRepository
    {
        private ToDoListContext _context;
        public EFTaskRepository(ToDoListContext temp)
        {
            _context = temp;
        }

        public List<Application> ToDoList => _context.ToDoList.ToList();

        public void AddTask(Application manager)
        {
            _context.Add(manager);
            _context.SaveChanges();
        }
    }
}
