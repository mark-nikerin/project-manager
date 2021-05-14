using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Tasks;

namespace ProjectManager.Services.Interfaces.Tasks
{
    public interface ITaskTypesService
    {
        Task<IReadOnlyCollection<TaskTypeDTO>> GetTypes(int projectId); 
        Task<TaskTypeDTO> AddType(int projectId, TaskTypeDTO model);
        Task<TaskTypeDTO> UpdateType(int projectId, int typeId, TaskTypeDTO model);
        Task DeleteType(int projectId, int typeId);
    }
}