using System;

namespace ProjectManager.Models.WorkTimeRecords.Requests
{
    public class AddWorkTimeRecordRequest
    {
        public string Description { get; set; }

        public double Hours { get; set; }

        public DateTimeOffset Date { get; set; }

        public int ProjectId { get; set; }

        public int TaskId { get; set; }
    }
}