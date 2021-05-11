using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class IterationConfiguration : IEntityTypeConfiguration<Iteration>
    {
        public void Configure(EntityTypeBuilder<Iteration> builder)
        {
            builder
                .HasOne(i => i.Project)
                .WithMany(p => p.Iterations)
                .HasForeignKey(i => i.ProjectId)
                .IsRequired();

            builder.HasMany(i => i.Tasks)
                .WithOne(t => t.Iteration)
                .HasForeignKey(t => t.IterationId)
                .IsRequired(false);

            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Title)
                .HasMaxLength(200);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(i => i.Description)
                .HasMaxLength(1000);
        }
    }
}