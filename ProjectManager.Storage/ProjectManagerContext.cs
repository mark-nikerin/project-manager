using Microsoft.EntityFrameworkCore;
using ProjectManager.Storage.Configurations;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage
{
    public class ProjectManagerContext : DbContext
    {
        public const string MigrationHistoryTable = "__MigrationHistory";

        public ProjectManagerContext()
        {
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new IterationConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TaskTagConfiguration());
            modelBuilder.ApplyConfiguration(new TaskTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkTimeRecordConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=ProjectManagerContext;Trusted_Connection=True;",
                    x =>
                    {
                        x.MigrationsHistoryTable(MigrationHistoryTable);
                        x.MigrationsAssembly("ProjectManager.Storage");
                    });
            }
        }
    }
}