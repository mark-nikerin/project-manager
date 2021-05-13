using System;
using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Models.Tasks.Requests
{
    public class AddTaskRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskPriorityEnum Priority { get; set; }

        public DateTimeOffset DueToDate { get; set; }

        public int? AssigneeId { get; set; }

        public int ReporterId { get; set; }

        public int TypeId { get; set; }

        public int? StatusId { get; set; }
    }
}