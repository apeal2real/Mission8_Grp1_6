﻿
namespace Mission8_Grp1_6.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp) 
        { 
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();
    }
}
