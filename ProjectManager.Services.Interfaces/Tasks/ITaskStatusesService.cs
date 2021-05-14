using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Tasks;

namespace ProjectManager.Services.Interfaces.Tasks
{
    public interface ITaskStatusesService
    {
        Task<IReadOnlyCollection<TaskStatusDTO>> GetStatuses(int projectId);
        Task<TaskStatusDTO> AddStatus(int projectId, TaskStatusDTO model);
        Task<TaskStatusDTO> UpdateStatus(int projectId, int statusId, TaskStatusDTO model);
        Task DeleteStatus(int projectId, int statusId);
    }
}