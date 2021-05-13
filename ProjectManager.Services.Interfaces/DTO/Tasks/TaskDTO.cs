using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Services.Interfaces.DTO.Tasks
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TaskPriorityEnum Priority { get; set; }

        public int? AssigneeId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }
    }
}