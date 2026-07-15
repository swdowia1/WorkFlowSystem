using Microsoft.EntityFrameworkCore;

using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public DbSet<WorkLog> WorkLogs => Set<WorkLog>();
    }
}
