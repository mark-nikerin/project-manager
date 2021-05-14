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
    public class TaskTagsService : BaseService, ITaskTagsService
    {
        public TaskTagsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<TaskTagDTO>> GetTags(int projectId)
        {
            var tags = await _context.TaskTags
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return tags;
        }

        public async Task<TaskTagDTO> AddTag(int projectId, TaskTagDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, projectId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Tag with title '{model.Title}' already exists in this project");

            var tag = new TaskTag
            {
                Title = model.Title,
                ProjectId = projectId
            };

            await _context.TaskTags.AddAsync(tag);
            await _context.SaveChangesAsync();

            var addedTag = await _context.TaskTags
                .AsNoTracking()
                .Where(x => x.ProjectId == tag.ProjectId)
                .Where(x => x.Title == tag.Title)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedTag;
        }

        public async Task<TaskTagDTO> UpdateTag(int projectId, int tagId, TaskTagDTO model)
        {
            var tag = await _context.TaskTags
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == tagId)
                .FirstOrDefaultAsync();

            if (tag == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Tag with id={tagId} not found");

            if (await IsAlreadyExistsAsync(model.Title, projectId, tagId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Tag with title '{model.Title}' already exists in this project");

            tag.Title = model.Title;

            _context.TaskTags.Update(tag);
            await _context.SaveChangesAsync();

            var result = tag.ToDTO();
            return result;
        }

        public async Task DeleteTag(int projectId, int typeId)
        {
            var tag = await _context.TaskTags
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == typeId)
                .FirstOrDefaultAsync();

            if (tag != null)
            {
                _context.TaskTags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, int projectId, int? id = null)
        {
            var query = _context.TaskTags
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