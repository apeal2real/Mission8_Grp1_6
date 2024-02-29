using Microsoft.EntityFrameworkCore;

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
                new Task { TaskID = 1, Category = "Home" },
                new Task { TaskID = 2, Category = "School" },
                new Task { TaskID = 3, Category = "Work" },
                new Task { TaskID = 4, Category = "Church" }
               );
        }
    }
}
