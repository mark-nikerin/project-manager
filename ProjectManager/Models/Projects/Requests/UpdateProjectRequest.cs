using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Models.Projects.Requests
{
    public class UpdateProjectRequest : IdRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public ProjectTypeEnum Type { get; set; }
    }
}