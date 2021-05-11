using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Base;
using ProjectManager.Services.Interfaces.DTO.Enums;
using ProjectManager.Services.Interfaces.DTO.Projects;
using ProjectManager.Storage;

namespace ProjectManager.Services
{
    public class ProjectsService : BaseService, IProjectsService
    {
        protected ProjectsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<BaseServiceResult<IReadOnlyCollection<ProjectDTO>, ProjectsServiceErrorType>> GetProjects()
        {
            var result = new BaseServiceResult<IReadOnlyCollection<ProjectDTO>, ProjectsServiceErrorType>();

            var projects = await _context.Projects
                .Select(x => x.ToDTO())
                .ToListAsync();

            result.Value = projects;

            return result;
        }
    }
}