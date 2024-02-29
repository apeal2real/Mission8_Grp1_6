using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Mission8_Grp1_6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(
                 new Task { TaskID = 1, TaskName = "Task 1 Name", Quadrant = 1, Category = "Home", Completed = false },
                 new Task { TaskID = 2, TaskName = "Task 2 Name", Quadrant = 2, Category = "School", Completed = false },
                 new Task { TaskID = 3, TaskName = "Task 3 Name", Quadrant = 3, Category = "Work", Completed = false },
                 new Task { TaskID = 4, TaskName = "Task 4 Name", Quadrant = 4, Category = "Church", Completed = false }
            );
        }
    }
}
