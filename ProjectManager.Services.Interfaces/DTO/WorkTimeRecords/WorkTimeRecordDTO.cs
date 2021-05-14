using System;

namespace ProjectManager.Services.Interfaces.DTO.WorkTimeRecords
{
    public class WorkTimeRecordDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public DateTimeOffset Date { get; set; }

        public int ProjectId { get; set; }

        public int TaskId { get; set; }

        public int UserId { get; set; }
    }
}