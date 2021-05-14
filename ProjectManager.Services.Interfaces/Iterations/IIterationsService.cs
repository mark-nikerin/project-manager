using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Iterations;

namespace ProjectManager.Services.Interfaces.Iterations
{
    public interface IIterationsService
    {
        Task<IReadOnlyCollection<IterationDTO>> GetIterations(int projectId);
        Task<IterationDTO> GetIteration(int projectId, int iterationId);
        Task<IterationDTO> AddIteration(int projectId, IterationDTO model);
        Task<IterationDTO> UpdateIteration(int projectId, int iterationId, IterationDTO model);
        Task DeleteIteration(int projectId, int iterationId);
    }
}