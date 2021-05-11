using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.Title)
                .HasMaxLength(200);
            
            builder
                .Property(t => t.Description)
                .HasMaxLength(1000);

            builder
                .HasOne(t => t.Assignee)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.Reporter)
                .WithMany(u => u.ReportedTasks)
                .HasForeignKey(t => t.ReporterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.Status)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.StatusId)
                .IsRequired();

            builder
                .HasMany(t => t.Tags)
                .WithMany(u => u.Tasks);

            builder
                .HasOne(t => t.Type)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.TypeId)
                .IsRequired();

            builder
                .HasOne(t => t.ParentTask)
                .WithMany(p => p.LinkedTasks)
                .HasForeignKey(t => t.ParentTaskId)
                .IsRequired(false);

            builder
                .HasMany(t => t.Comments)
                .WithOne(c => c.Task)
                .HasForeignKey(c => c.TaskId)
                .IsRequired();

            builder
                .HasMany(t => t.LinkedTasks)
                .WithOne(l => l.ParentTask)
                .HasForeignKey(l => l.ParentTaskId)
                .IsRequired(false);

            builder
                .HasMany(t => t.WorkTimeRecords)
                .WithOne(w => w.Task)
                .HasForeignKey(w => w.TaskId)
                .IsRequired();
        }
    }
}