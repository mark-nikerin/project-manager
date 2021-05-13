using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Tasks;

namespace ProjectManager.Services.Interfaces.Tasks
{
    public interface ITasksService
    {
        Task<IReadOnlyCollection<TaskDTO>> GetBoardTasks(int boardId);
        Task<TaskDetailsDTO> GetBoardTask(int boardId, int taskId);
        Task<TaskDetailsDTO> AddBoardTask(int boardId, TaskDetailsDTO model);
        Task<TaskDetailsDTO> UpdateBoardTask(int boardId, TaskDetailsDTO model);
        Task DeleteBoardTask(int boardId, int taskId);
        Task<IReadOnlyCollection<TaskDTO>> GetIterationTasks(int iterationId);
        Task<TaskDetailsDTO> GetIterationTask(int iterationId, int taskId);
        Task<TaskDetailsDTO> AddIterationTask(int iterationId, TaskDetailsDTO model);
        Task<TaskDetailsDTO> UpdateIterationTask(int iterationId, TaskDetailsDTO model);
        Task DeleteIterationTask(int iterationId, int taskId);
    }
}