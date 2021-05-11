using ProjectManager.Services.Interfaces.DTO.Projects;
using ProjectManager.Storage.Models;

namespace ProjectManager.Services.Extensions
{
    public static class MappingExtensions
    {
        public static ProjectDTO ToDTO(this Project project)
        {
            if (project == null)
            {
                return null;
            }

            return new ProjectDTO
            {
            };
        }
    }
}