using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Requests.Statuses;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Tasks
{
    public class StatusesController : ControllerBase
    {
        private readonly ITaskStatusesService _statusesService;

        public StatusesController(ITaskStatusesService statusesService)
        {
            _statusesService = statusesService;
        }

        [HttpGet(Routes.Tasks.Statuses.GetStatuses)]
        public async Task<IActionResult> GetTypes(int projectId)
        {
            var result = await _statusesService.GetStatuses(projectId);
            return Ok(result);
        }

        [HttpPost(Routes.Tasks.Statuses.AddStatus)]
        public async Task<IActionResult> AddType(int projectId, AddTaskStatusRequest request)
        {
            var dto = new TaskStatusDTO
            {
                Title = request.Title
            };

            var result = await _statusesService.AddStatus(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.Statuses.UpdateStatus)]
        public async Task<IActionResult> UpdateType(int projectId, int id, UpdateTaskStatusRequest request)
        {
            var dto = new TaskStatusDTO
            {
                Title = request.Title
            };

            var result = await _statusesService.UpdateStatus(projectId, id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.Statuses.DeleteStatus)]
        public async Task<IActionResult> DeleteType(int projectId, int id)
        {
            await _statusesService.DeleteStatus(projectId, id);
            return Ok();
        }
    }
}