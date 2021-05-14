using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Iterations.Requests;
using ProjectManager.Services.Interfaces.DTO.Iterations;
using ProjectManager.Services.Interfaces.Iterations;

namespace ProjectManager.Controllers.Projects.Iterations
{
    [ApiController]
    public class IterationsController : ControllerBase
    {
        private readonly IIterationsService _iterationsService;

        public IterationsController(IIterationsService iterationsService)
        {
            _iterationsService = iterationsService;
        }

        [HttpGet(Routes.Projects.Iterations.GetIterations)]
        public async Task<IActionResult> GetIterations(int projectId)
        {
            var result = await _iterationsService.GetIterations(projectId);
            return Ok(result);
        }

        [HttpGet(Routes.Projects.Iterations.GetIteration)]
        public async Task<IActionResult> GetIteration(int projectId, int id)
        {
            var result = await _iterationsService.GetIteration(projectId, id);
            return Ok(result);
        }

        [HttpPost(Routes.Projects.Iterations.AddIteration)]
        public async Task<IActionResult> AddIteration(int projectId, AddIterationRequest request)
        {
            var dto = new IterationDTO
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var result = await _iterationsService.AddIteration(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Projects.Iterations.UpdateIteration)]
        public async Task<IActionResult> UpdateIteration(int projectId, int id, UpdateIterationRequest request)
        {
            var dto = new IterationDTO
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var result = await _iterationsService.UpdateIteration(projectId, id, dto);

            return Ok(result);
        }

        [HttpDelete(Routes.Projects.Iterations.DeleteIteration)]
        public async Task<IActionResult> DeleteIteration(int projectId, int id)
        {
            await _iterationsService.DeleteIteration(projectId, id);

            return Ok();
        }
    }
}