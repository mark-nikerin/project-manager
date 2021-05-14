using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Statuses.Requests;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Projects.Tasks
{
    public class TaskStatusesController : ControllerBase
    {
        private readonly ITaskStatusesService _statusesService;

        public TaskStatusesController(ITaskStatusesService statusesService)
        {
            _statusesService = statusesService;
        }

        [HttpGet(Routes.Projects.TaskStatuses.GetStatuses)]
        public async Task<IActionResult> GetTypes(int projectId)
        {
            var result = await _statusesService.GetStatuses(projectId);
            return Ok(result);
        }

        [HttpPost(Routes.Projects.TaskStatuses.AddStatus)]
        public async Task<IActionResult> AddType(int projectId, AddTaskStatusRequest request)
        {
            var dto = new TaskStatusDTO
            {
                Title = request.Title
            };

            var result = await _statusesService.AddStatus(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Projects.TaskStatuses.UpdateStatus)]
        public async Task<IActionResult> UpdateType(int projectId, int id, UpdateTaskStatusRequest request)
        {
            var dto = new TaskStatusDTO
            {
                Title = request.Title
            };

            var result = await _statusesService.UpdateStatus(projectId, id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Projects.TaskStatuses.DeleteStatus)]
        public async Task<IActionResult> DeleteType(int projectId, int id)
        {
            await _statusesService.DeleteStatus(projectId, id);
            return Ok();
        }
    }
}