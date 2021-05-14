using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Services.Interfaces.Tasks;
using ProjectManager.Storage;
using Task = System.Threading.Tasks.Task;
using TaskStatus = ProjectManager.Storage.Models.TaskStatus;

namespace ProjectManager.Services.Tasks
{
    public class TaskStatusesService : BaseService, ITaskStatusesService
    {
        public TaskStatusesService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<TaskStatusDTO>> GetStatuses(int projectId)
        {
            var defaultStatusesQuery = _context.TaskStatuses
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId);

            var projectStatusesQuery = _context.TaskStatuses
                .AsNoTracking()
                .Where(x => !x.ProjectId.HasValue);

            var types = await defaultStatusesQuery
                .Concat(projectStatusesQuery)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return types;
        }

        public async Task<TaskStatusDTO> AddStatus(int projectId, TaskStatusDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, projectId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Status with title '{model.Title}' already exists in this project");

            var status = new TaskStatus
            {
                Title = model.Title,
                ProjectId = projectId
            };

            await _context.TaskStatuses.AddAsync(status);
            await _context.SaveChangesAsync();

            var addedType = await _context.TaskStatuses
                .AsNoTracking()
                .Where(x => x.ProjectId == status.ProjectId)
                .Where(x => x.Title == status.Title)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedType;
        }

        public async Task<TaskStatusDTO> UpdateStatus(int projectId, int statusId, TaskStatusDTO model)
        {
            var status = await _context.TaskStatuses
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == statusId)
                .FirstOrDefaultAsync();

            if (status == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Status with id={statusId} not found");

            if (await IsAlreadyExistsAsync(model.Title, projectId, statusId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Status with title '{model.Title}' already exists in this project");

            status.Title = model.Title;

            _context.TaskStatuses.Update(status);
            await _context.SaveChangesAsync();

            var result = status.ToDTO();
            return result;
        }

        public async Task DeleteStatus(int projectId, int statusId)
        {
            var status = await _context.TaskStatuses
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == statusId)
                .FirstOrDefaultAsync();

            _context.TaskStatuses.Remove(status);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, int projectId, int? id = null)
        {
            var query = _context.TaskStatuses
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Title == title);

            query = id.HasValue
                ? query.Where(x => x.Id != id.Value)
                : query;

            return await query.AnyAsync();
        }
    }
}