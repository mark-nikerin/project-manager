using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Tasks.Board.Requests;
using ProjectManager.Models.Tasks.Iteration.Requests;
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
        public async Task<IActionResult> GetTask(BoardTaskIdRequest request)
        {
            var result = await _tasksService.GetBoardTask(request.BoardId, request.Id);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.BoardTasks.AddTask)]
        public async Task<IActionResult> AddTask(AddBoardTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                TypeId = request.TypeId,
                StatusId = request.StatusId.GetValueOrDefault()
            };

            var result = await _tasksService.AddBoardTask(request.BoardId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.BoardTasks.UpdateTask)]
        public async Task<IActionResult> UpdateTask(UpdateBoardTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                TypeId = request.TypeId,
                StatusId = request.StatusId.GetValueOrDefault()
            };

            var result = await _tasksService.UpdateBoardTask(request.BoardId, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.BoardTasks.DeleteTask)]
        public async Task<IActionResult> DeleteTask(BoardTaskIdRequest request)
        {
            await _tasksService.DeleteBoardTask(request.BoardId, request.Id);

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
        public async Task<IActionResult> GetTask(IterationTaskIdRequest request)
        {
            var result = await _tasksService.GetIterationTask(request.IterationId, request.Id);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.IterationTasks.AddTask)]
        public async Task<IActionResult> AddTask(AddIterationTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                TypeId = request.TypeId,
                StatusId = request.StatusId.GetValueOrDefault()
            };

            var result = await _tasksService.AddIterationTask(request.IterationId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.IterationTasks.UpdateTask)]
        public async Task<IActionResult> UpdateTask(UpdateIterationTaskRequest request)
        {
            var dto = new TaskDetailsDTO
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                DueToDate = request.DueToDate,
                Priority = request.Priority,
                AssigneeId = request.AssigneeId,
                ReporterId = request.ReporterId,
                TypeId = request.TypeId,
                StatusId = request.StatusId.GetValueOrDefault()
            };

            var result = await _tasksService.UpdateIterationTask(request.IterationId, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.IterationTasks.DeleteTask)]
        public async Task<IActionResult> DeleteTask(IterationTaskIdRequest request)
        {
            await _tasksService.DeleteIterationTask(request.IterationId, request.Id);

            return Ok();
        }

        #endregion

    }
}