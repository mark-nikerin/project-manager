using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Storage
{
    public class ProjectManagerContext : DbContext
    {
        public const string MigrationHistoryTable = "__MigrationHistory";

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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