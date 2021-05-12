using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.Title)
                .HasMaxLength(100);

            builder
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskStatuses)
                .HasForeignKey(t => t.ProjectId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId)
                .IsRequired(); 
        }
    }
}