using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Projects;
using ProjectManager.Storage;

namespace ProjectManager.Services
{
    public class ProjectsService : BaseService, IProjectsService
    {
        protected ProjectsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<ProjectDTO>> GetProjects()
        {
            var projects = await _context.Projects
                .AsNoTracking()
                .Select(x => x.ToDTO())
                .ToListAsync();

            return projects;
        }

        public async Task<ProjectDTO> GetProject(int projectId)
        {
            var project = await _context.Projects
                .AsNoTracking()
                .Where(x => x.Id == projectId)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            if (project == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Project with id={projectId} not found");

            return project;
        }
    }
}