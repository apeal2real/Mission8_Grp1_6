
namespace Mission8_Grp1_6.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp) 
        { 
            _context = temp;
        }
        public List<Category> Categories => _context.Categories.ToList();
        public List<Task> Tasks => _context.Tasks.ToList();

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void RemoveTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
