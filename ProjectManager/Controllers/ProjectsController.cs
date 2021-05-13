using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Projects.Requests;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Projects;
using ProjectManager.Services.Interfaces.Projects;

namespace ProjectManager.Controllers
{
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projects;

        public ProjectsController(IProjectsService projects)
        {
            _projects = projects;
        }

        [HttpGet(Routes.Projects.GetProjects)]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projects.GetProjects();

            return Ok(result);
        }

        [HttpGet(Routes.Projects.GetProject)]
        public async Task<IActionResult> GetProject(int id)
        {
            var result = await _projects.GetProject(id);

            return Ok(result);
        }

        [HttpPost(Routes.Projects.AddProject)]
        public async Task<IActionResult> AddProject(AddProjectRequest request)
        {
            var dto = new ProjectDTO
            {
                Title = request.Title,
                Description = request.Description,
                Prefix = request.Prefix,
                Type = request.Type
            };

            var result = await _projects.AddProject(dto);

            return Ok(result);
        }

        [HttpPut(Routes.Projects.UpdateProject)]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectRequest request)
        {
            var dto = new ProjectDTO
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                Prefix = request.Prefix,
                Type = request.Type
            };

            var result = await _projects.UpdateProject(dto);

            return Ok(result);
        }

        [HttpDelete(Routes.Projects.DeleteProject)]
        public async Task<IActionResult> UpdateProject(int id)
        {
            await _projects.DeleteProject(id);

            return Ok();
        }
    }
}