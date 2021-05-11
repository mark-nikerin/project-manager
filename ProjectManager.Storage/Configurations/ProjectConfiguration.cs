using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Title)
                .HasMaxLength(200);
            
            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .Property(p => p.Prefix)
                .HasMaxLength(10);
        }
    }
}