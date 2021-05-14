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
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services.Tasks
{
    public class TaskTypesService : BaseService, ITaskTypesService
    {
        public TaskTypesService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<TaskTypeDTO>> GetTypes(int projectId)
        {
            var defaultTypesQuery = _context.TaskTypes
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId);

            var projectTypesQuery = _context.TaskTypes
                .AsNoTracking()
                .Where(x => !x.ProjectId.HasValue);

            var types = await defaultTypesQuery
                .Concat(projectTypesQuery)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return types;
        }

        public async Task<TaskTypeDTO> AddType(int projectId, TaskTypeDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, projectId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Type with title '{model.Title}' already exists in this project");

            var type = new TaskType
            {
                Title = model.Title,
                Description = model.Description,
                ProjectId = projectId
            };

            await _context.TaskTypes.AddAsync(type);
            await _context.SaveChangesAsync();

            var addedType = await _context.TaskTypes
                .AsNoTracking()
                .Where(x => x.ProjectId == type.ProjectId)
                .Where(x => x.Title == type.Title)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedType;
        }

        public async Task<TaskTypeDTO> UpdateType(int projectId, int typeId, TaskTypeDTO model)
        {
            var type = await _context.TaskTypes
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == typeId)
                .FirstOrDefaultAsync();

            if (type == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Type with id={typeId} not found");

            if (await IsAlreadyExistsAsync(model.Title, projectId, typeId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Type with title '{model.Title}' already exists in this project");

            type.Title = model.Title;
            type.Description = model.Description;

            _context.TaskTypes.Update(type);
            await _context.SaveChangesAsync();

            var result = type.ToDTO();
            return result;
        }

        public async Task DeleteType(int projectId, int typeId)
        {
            var type = await _context.TaskTypes
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == typeId)
                .FirstOrDefaultAsync();

            _context.TaskTypes.Remove(type);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, int projectId, int? id = null)
        {
            var query = _context.TaskTypes
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