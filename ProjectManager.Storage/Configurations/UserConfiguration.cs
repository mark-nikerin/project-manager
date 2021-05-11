using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.FirstName)
                .HasMaxLength(100);

            builder
                .Property(t => t.LastName)
                .HasMaxLength(100);

            builder
                .Property(t => t.SecondName)
                .HasMaxLength(100);

            builder
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .IsRequired();

            builder
                .HasMany(u => u.Projects)
                .WithMany(c => c.Users);

            builder
                .HasMany(u => u.AssignedTasks)
                .WithOne(t => t.Assignee)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(u => u.ReportedTasks)
                .WithOne(t => t.Reporter)
                .HasForeignKey(t => t.ReporterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}