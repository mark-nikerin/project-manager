using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class TaskTagConfiguration : IEntityTypeConfiguration<TaskTag>
    {
        public void Configure(EntityTypeBuilder<TaskTag> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.Title)
                .HasMaxLength(100);

            builder
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskTags)
                .HasForeignKey(t => t.ProjectId)
                .IsRequired(false);

            builder
                .HasMany(t => t.Tasks)
                .WithMany(t => t.Tags);
        }
    }
}