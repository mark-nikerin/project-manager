
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projects;

        public ProjectsController(ProjectsService projects)
        {
            _projects = projects;
        }

        [HttpGet(Routes.Projects.GetProjects)]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projects.GetProjects();

            return Ok(result);
        }

        [HttpPost(Routes.Projects.AddProject)]
        public async Task<IActionResult> AddProject()
        {

            return null;
        }
    }
}