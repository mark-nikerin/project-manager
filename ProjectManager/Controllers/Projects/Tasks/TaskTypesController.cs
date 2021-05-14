using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Types.Requests;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Projects.Tasks
{
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private readonly ITaskTypesService _typesService;

        public TaskTypesController(ITaskTypesService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet(Routes.Projects.TaskTypes.GetTypes)]
        public async Task<IActionResult> GetTypes(int projectId)
        {
            var result = await _typesService.GetTypes(projectId);
            return Ok(result);
        }

        [HttpPost(Routes.Projects.TaskTypes.AddType)]
        public async Task<IActionResult> AddType(int projectId, AddTaskTypeRequest request)
        {
            var dto = new TaskTypeDTO
            {
                Title = request.Title,
                Description = request.Description
            };

            var result = await _typesService.AddType(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Projects.TaskTypes.UpdateType)]
        public async Task<IActionResult> UpdateType(int projectId, int id, UpdateTaskTypeRequest request)
        {
            var dto = new TaskTypeDTO
            {
                Title = request.Title,
                Description = request.Description
            };

            var result = await _typesService.UpdateType(projectId, id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Projects.TaskTypes.DeleteType)]
        public async Task<IActionResult> DeleteType(int projectId, int id)
        {
            await _typesService.DeleteType(projectId, id);
            return Ok();
        }
    }
}