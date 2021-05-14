using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Requests.Types;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Tasks
{
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITaskTypesService _typesService;

        public TypesController(ITaskTypesService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet(Routes.Tasks.Types.GetTypes)]
        public async Task<IActionResult> GetTypes(int projectId)
        {
            var result = await _typesService.GetTypes(projectId);
            return Ok(result);
        }

        [HttpPost(Routes.Tasks.Types.AddType)]
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

        [HttpPut(Routes.Tasks.Types.UpdateType)]
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

        [HttpDelete(Routes.Tasks.Types.DeleteType)]
        public async Task<IActionResult> DeleteType(int projectId, int id)
        {
            await _typesService.DeleteType(projectId, id);
            return Ok();
        }
    }
}