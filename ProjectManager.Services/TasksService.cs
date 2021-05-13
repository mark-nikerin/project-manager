using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Storage;

namespace ProjectManager.Services
{
    public class TasksService : BaseService, ITasksService
    {
        public TasksService(ProjectManagerContext context) : base(context)
        {
        }

        #region Board

        public async Task<IReadOnlyCollection<TaskDTO>> GetBoardTasks(int boardId)
        {
            var tasks = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.BoardId == boardId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return tasks;
        }

        public async Task<TaskDetailsDTO> GetBoardTask(int boardId, int taskId)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.BoardId == boardId)
                .Where(x => x.Id == taskId)
                .Select(x => x.ToDetailsDTO())
                .FirstOrDefaultAsync();

            if (task == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Task with id={taskId} not found");

            return task;
        }

        public async Task<TaskDetailsDTO> AddBoardTask(int boardId, TaskDetailsDTO model)
        {
            var currentDateTime = DateTimeOffset.UtcNow;
            var task = new ProjectManager.Storage.Models.Task
            {
                Title = model.Title,
                Description = model.Description,
                UpdatedDate = currentDateTime,
                CreatedDate = currentDateTime,
                Priority = model.Priority.ToEntity(),
                DueToDate = model.DueToDate,
                TypeId = model.Type.Id,
                StatusId = model.Status.Id,
                BoardId = boardId,
                ParentTaskId = model.ParentTaskId,
                AssigneeId = model.AssigneeId,
                ReporterId = model.ReporterId
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            var addedTask = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.BoardId == task.BoardId)
                .Where(x => x.Title == task.Title)
                .Where(x => x.CreatedDate == task.CreatedDate)
                .Select(x => x.ToDetailsDTO())
                .FirstOrDefaultAsync();

            return addedTask;
        }

        public async Task<TaskDetailsDTO> UpdateBoardTask(int boardId, TaskDetailsDTO model)
        {
            var task = await _context.Tasks
                .Where(x => x.BoardId == boardId)
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            if (task == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Task with id={model.Id} not found");

            task.Title = model.Title;
            task.Description = model.Description;
            task.UpdatedDate = DateTimeOffset.UtcNow;
            task.Priority = model.Priority.ToEntity();
            task.DueToDate = model.DueToDate;
            task.TypeId = model.Type.Id;
            task.StatusId = model.Status.Id;
            task.ParentTaskId = model.ParentTaskId;
            task.AssigneeId = model.AssigneeId;
            task.ReporterId = model.ReporterId;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return task.ToDetailsDTO();
        }

        public async Task DeleteBoardTask(int boardId, int taskId)
        {
            var task = await _context.Tasks
                .Where(x => x.BoardId == boardId)
                .Where(x => x.Id == taskId)
                .FirstOrDefaultAsync();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Iteration

        public async Task<IReadOnlyCollection<TaskDTO>> GetIterationTasks(int iterationId)
        {
            var tasks = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.IterationId == iterationId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return tasks;
        }

        public async Task<TaskDetailsDTO> GetIterationTask(int iterationId, int taskId)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.IterationId == iterationId)
                .Where(x => x.Id == taskId)
                .Select(x => x.ToDetailsDTO())
                .FirstOrDefaultAsync();

            if (task == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Task with id={taskId} not found");

            return task;
        }

        public async Task<TaskDetailsDTO> AddIterationTask(int iterationId, TaskDetailsDTO model)
        {
            var currentDateTime = DateTimeOffset.UtcNow;
            var task = new ProjectManager.Storage.Models.Task
            {
                Title = model.Title,
                Description = model.Description,
                UpdatedDate = currentDateTime,
                CreatedDate = currentDateTime,
                Priority = model.Priority.ToEntity(),
                DueToDate = model.DueToDate,
                TypeId = model.Type.Id,
                StatusId = model.Status.Id,
                BoardId = iterationId,
                ParentTaskId = model.ParentTaskId,
                AssigneeId = model.AssigneeId,
                ReporterId = model.ReporterId
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            var addedTask = await _context.Tasks
                .AsNoTracking()
                .Where(x => x.IterationId == task.IterationId)
                .Where(x => x.Title == task.Title)
                .Where(x => x.CreatedDate == task.CreatedDate)
                .Select(x => x.ToDetailsDTO())
                .FirstOrDefaultAsync();

            return addedTask;
        }

        public async Task<TaskDetailsDTO> UpdateIterationTask(int iterationId, TaskDetailsDTO model)
        {
            var task = await _context.Tasks
                .Where(x => x.IterationId == iterationId)
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            if (task == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Task with id={model.Id} not found");

            task.Title = model.Title;
            task.Description = model.Description;
            task.UpdatedDate = DateTimeOffset.UtcNow;
            task.Priority = model.Priority.ToEntity();
            task.DueToDate = model.DueToDate;
            task.TypeId = model.Type.Id;
            task.StatusId = model.Status.Id;
            task.ParentTaskId = model.ParentTaskId;
            task.AssigneeId = model.AssigneeId;
            task.ReporterId = model.ReporterId;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return task.ToDetailsDTO();
        }

        public async Task DeleteIterationTask(int iterationId, int taskId)
        {
            var task = await _context.Tasks
                .Where(x => x.IterationId == iterationId)
                .Where(x => x.Id == taskId)
                .FirstOrDefaultAsync();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}