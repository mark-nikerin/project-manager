using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Requests;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Tasks;

namespace ProjectManager.Controllers
{
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        #region Board

        [HttpGet(Routes.Tasks.BoardTasks.GetTasks)]
        public async Task<IActionResult> GetBoardTasks(int boardId)
        {
            var result = await _tasksService.GetBoardTasks(boardId);
            return Ok(result);
        }

        [HttpGet(Routes.Tasks.BoardTasks.GetTask)]
        public async Task<IActionResult> GetBoardTask(int boardId, int id)
        {
            var result = await _tasksService.GetBoardTask(boardId, id);
            return Ok(result);
        }

        [HttpPost(Routes.Tasks.BoardTasks.AddTask)]
        public async Task<IActionResult> AddBoardTask(int boardId, AddTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                Type = new TaskTypeDTO
                {
                    Id = request.TypeId
                },
                Status = new TaskStatusDTO
                {
                    Id = request.StatusId.GetValueOrDefault()
                }
            };

            var result = await _tasksService.AddBoardTask(boardId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.BoardTasks.UpdateTask)]
        public async Task<IActionResult> UpdateBoardTask( int boardId, int id, UpdateTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                Type = new TaskTypeDTO
                {
                    Id = request.TypeId
                },
                Status = new TaskStatusDTO
                {
                    Id = request.StatusId.GetValueOrDefault()
                }
            };

            var result = await _tasksService.UpdateBoardTask(boardId, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.BoardTasks.DeleteTask)]
        public async Task<IActionResult> DeleteBoardTask(int boardId, int id)
        {
            await _tasksService.DeleteBoardTask(boardId, id);

            return Ok();
        }

        #endregion

        #region Iteration

        [HttpGet(Routes.Tasks.IterationTasks.GetTasks)]
        public async Task<IActionResult> GetIterationTasks(int iterationId)
        {
            var result = await _tasksService.GetIterationTasks(iterationId);
            return Ok(result);
        }

        [HttpGet(Routes.Tasks.IterationTasks.GetTask)]
        public async Task<IActionResult> GetTask(int iterationId, int id)
        {
            var result = await _tasksService.GetIterationTask(iterationId, id);
            return Ok(result);
        }

        [HttpPost(Routes.Tasks.IterationTasks.AddTask)]
        public async Task<IActionResult> AddIterationTask(int iterationId, AddTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                Type = new TaskTypeDTO
                {
                    Id = request.TypeId
                },
                Status = new TaskStatusDTO
                {
                    Id = request.StatusId.GetValueOrDefault()
                }
            };

            var result = await _tasksService.AddIterationTask(iterationId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.IterationTasks.UpdateTask)]
        public async Task<IActionResult> UpdateIterationTask(int iterationId, int id, UpdateTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                Type = new TaskTypeDTO
                {
                    Id = request.TypeId
                },
                Status = new TaskStatusDTO
                {
                    Id = request.StatusId.GetValueOrDefault()
                }
            };

            var result = await _tasksService.UpdateIterationTask(iterationId, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.IterationTasks.DeleteTask)]
        public async Task<IActionResult> DeleteIterationTask(int iterationId, int id)
        {
            await _tasksService.DeleteIterationTask(iterationId, id);

            return Ok();
        }

        #endregion

    }
}