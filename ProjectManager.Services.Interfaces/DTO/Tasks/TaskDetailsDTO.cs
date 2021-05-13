using System;

namespace ProjectManager.Services.Interfaces.DTO.Tasks
{
    public class TaskDetailsDTO : TaskDTO
    {
        public string Description { get; set; }

        public int ReporterId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public DateTimeOffset DueToDate { get; set; }
         
        public int? ParentTaskId { get; set; }
    }
}