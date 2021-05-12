using System;
using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Services.Interfaces.DTO.Projects
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }
        
        public ProjectTypeEnum Type { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }
    }
}