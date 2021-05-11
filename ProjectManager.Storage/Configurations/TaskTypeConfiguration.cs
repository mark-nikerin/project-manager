using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class TaskTypeConfiguration : IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.Title)
                .HasMaxLength(100);

            builder
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskTypes)
                .HasForeignKey(t => t.ProjectId)
                .IsRequired(false);

            builder
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Type)
                .HasForeignKey(t => t.TypeId)
                .IsRequired(); 
        }
    }
}