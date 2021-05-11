
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services;
using ProjectManager.Services.Interfaces.DTO.Base;
using ProjectManager.Services.Interfaces.DTO.Enums;

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

            if (result.Error != null)
            {
                CreateErrorResult(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost(Routes.Projects.AddProject)]
        public async Task<IActionResult> AddProject()
        {

            return null;
        }

        private IActionResult CreateErrorResult(ErrorInfo<ProjectsServiceErrorType> error)
        {
            switch (error.ErrorType)
            {

            }

            return Ok();
        }
    }
}