using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Services.Interfaces.DTO.Tasks
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TaskPriorityEnum Priority { get; set; }

        public int? AssigneeId { get; set; }

        public TaskTypeDTO Type { get; set; }

        public TaskStatusDTO Status { get; set; }
    }
}