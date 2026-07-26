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
        public DbSet<Project> Projects => Set<Project>();

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public DbSet<WorkLog> WorkLogs => Set<WorkLog>();
        public DbSet<Tag> Tags => Set<Tag>();

        public DbSet<TaskTag> TaskTags => Set<TaskTag>();

        public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateAuditFields();

            return base.SaveChanges();
        }

        private void UpdateAuditFields()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added ||
                    entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAtUtc = now;
                }
            }
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TaskTag>()
                .HasKey(x => new
                {
                    x.TaskId,
                    x.TagId
                });


            modelBuilder.Entity<TaskTag>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskTags)
                .HasForeignKey(x => x.TaskId);



            modelBuilder.Entity<TaskTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.TaskTags)
                .HasForeignKey(x => x.TagId);

        }
    }
}
