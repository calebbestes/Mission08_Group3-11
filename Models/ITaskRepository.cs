namespace Mission08_Group3_11.Models
{
    public interface ITaskRepository
    {
        IQueryable <Application> ToDoList {  get; }
        IQueryable<Category> Categories { get; }

        public void DeleteApplication(Application m);
       
    }
}
