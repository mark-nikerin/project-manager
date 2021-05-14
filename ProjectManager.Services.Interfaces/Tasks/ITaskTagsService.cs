using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Tasks;

namespace ProjectManager.Services.Interfaces.Tasks
{
    public interface ITaskTagsService
    {
        Task<IReadOnlyCollection<TaskTagDTO>> GetTags(int projectId);
        Task<TaskTagDTO> AddTag(int projectId, TaskTagDTO model);
        Task<TaskTagDTO> UpdateTag(int projectId, int tagId, TaskTagDTO model);
        Task DeleteTag(int projectId, int tagId);
    }
}