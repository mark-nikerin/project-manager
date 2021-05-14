using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Tags.Requests;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Projects.Tasks
{
    public class TaskTagsController : ControllerBase
    {
        private readonly ITaskTagsService _tagsService;

        public TaskTagsController(ITaskTagsService tagsService)
        {
            _tagsService = tagsService;
        } 

        [HttpGet(Routes.Projects.TaskTags.GetTags)]
        public async Task<IActionResult> GetTypes(int projectId)
        {
            var result = await _tagsService.GetTags(projectId);
            return Ok(result);
        }

        [HttpPost(Routes.Projects.TaskTags.AddTag)]
        public async Task<IActionResult> AddType(int projectId, AddTaskTagRequest request)
        {
            var dto = new TaskTagDTO
            {
                Title = request.Title
            };

            var result = await _tagsService.AddTag(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Projects.TaskTags.UpdateTag)]
        public async Task<IActionResult> UpdateType(int projectId, int id, UpdateTaskTagRequest request)
        {
            var dto = new TaskTagDTO
            {
                Title = request.Title
            };

            var result = await _tagsService.UpdateTag(projectId, id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Projects.TaskTags.DeleteTag)]
        public async Task<IActionResult> DeleteType(int projectId, int id)
        {
            await _tagsService.DeleteTag(projectId, id);
            return Ok();
        }
    }
}