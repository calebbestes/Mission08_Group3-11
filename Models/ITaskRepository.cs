namespace Mission08_Group3_11.Models
{
    public interface ITaskRepository
    {
        IQueryable ToDoList { get; }
        IQueryable Categories { get; }
    }
}