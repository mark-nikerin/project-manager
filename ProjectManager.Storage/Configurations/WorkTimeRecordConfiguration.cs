using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Storage.Models;

namespace ProjectManager.Storage.Configurations
{
    public class WorkTimeRecordConfiguration : IEntityTypeConfiguration<WorkTimeRecord>
    {
        public void Configure(EntityTypeBuilder<WorkTimeRecord> builder)
        {

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();
            
            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .HasOne(w => w.Task)
                .WithMany(t => t.WorkTimeRecords)
                .HasForeignKey(w => w.TaskId)
                .IsRequired();

            builder
                .HasOne(w => w.User)
                .WithMany(u => u.WorkTimeRecords)
                .HasForeignKey(w => w.UserId)
                .IsRequired();
        }
    }
}