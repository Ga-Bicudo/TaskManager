using APITaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace APITaskManager.Data
{
    public class TaskManagerDbContext : DbContext
    {
        
        public DbSet<Domain.Task> Task { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<TaskComment> TaskComment { get; set; }
        public DbSet<TaskHistory> TaskHistory { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=TaskManager;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}
