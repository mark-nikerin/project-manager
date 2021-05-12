using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Projects;

namespace ProjectManager.Services.Interfaces
{
    public interface IProjectsService
    {
        Task<IReadOnlyCollection<ProjectDTO>> GetProjects();
        Task<ProjectDTO> GetProject(int projectId);
        Task<ProjectDTO> AddProject(ProjectDTO model);
        Task<ProjectDTO> UpdateProject(ProjectDTO model);
        Task DeleteProject(int projectId);
    }
}