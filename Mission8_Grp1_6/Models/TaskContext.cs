﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Mission8_Grp1_6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryID = 1, CategoryName = "Home" },
                 new Category { CategoryID = 2, CategoryName = "School" },
                 new Category { CategoryID = 3, CategoryName = "Work" },
                 new Category { CategoryID = 4, CategoryName = "Church" }
            );
        }
    }
}
