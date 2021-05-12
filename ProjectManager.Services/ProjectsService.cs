using System;
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
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services
{
    public class ProjectsService : BaseService, IProjectsService
    {
        public ProjectsService(ProjectManagerContext context) : base(context)
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

        public async Task<ProjectDTO> AddProject(ProjectDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, model.Prefix))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Project with title '{model.Title}' or prefix '{model.Prefix}' already exists");

            var currentDateTime = DateTimeOffset.UtcNow;
            var project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                Prefix = model.Prefix,
                Type = model.Type.ToEntity(),
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            var addedProject = await _context.Projects
                .Where(x => x.Title == project.Title && x.Prefix == project.Prefix)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedProject;
        }

        public async Task<ProjectDTO> UpdateProject(ProjectDTO model)
        {
            var project = await _context.Projects
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            if (project == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Project with id={model.Id} not found");

            if (await IsAlreadyExistsAsync(model.Title, model.Prefix, model.Id))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Project with title '{model.Title}' or prefix '{model.Prefix}' already exists");

            project.Description = model.Description;
            project.Title = model.Title;
            project.Prefix = model.Prefix;
            project.UpdatedDate = DateTimeOffset.UtcNow;

            _context.Update(project);
            await _context.SaveChangesAsync();

            return project.ToDTO();
        }

        public async Task DeleteProject(int projectId)
        {
            var project = await _context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefaultAsync();

            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, string prefix, int? id = null)
        {
            var query = _context.Projects
                .AsNoTracking()
                .Where(x => x.Title == title || x.Prefix == prefix);

            query = id.HasValue
                ? query.Where(x => x.Id != id.Value)
                : query;

            return await query.AnyAsync();
        }
    }
}