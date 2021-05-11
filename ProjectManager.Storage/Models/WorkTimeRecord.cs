using System;

namespace ProjectManager.Storage.Models
{
    public class WorkTimeRecord
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public DateTimeOffset Date { get; set; }

        public int ProjectId { get; set; }

        public int TaskId { get; set; }

        public int UserId { get; set; }

        public virtual Task Task { get; set; }

        public virtual User User { get; set; }

    }
}