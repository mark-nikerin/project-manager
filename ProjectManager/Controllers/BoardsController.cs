using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Boards.Requests;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Projects;

namespace ProjectManager.Controllers
{
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardsService _boardsService;

        public BoardsController(IBoardsService boardsService)
        {
            _boardsService = boardsService;
        }

        [HttpGet(Routes.Boards.GetBoards)]
        public async Task<IActionResult> GetBoards(int projectId)
        {
            var result = await _boardsService.GetBoards(projectId);
            return Ok(result);
        }

        [HttpGet(Routes.Boards.GetBoard)]
        public async Task<IActionResult> GetBoard(BoardIdRequest request)
        {
            var result = await _boardsService.GetBoard(request.ProjectId, request.Id);
            return Ok(result);
        }

        [HttpPut(Routes.Boards.AddBoard)]
        public async Task<IActionResult> AddBoard(AddBoardRequest request)
        {
            var dto = new BoardDTO
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId
            };

            var result = await _boardsService.AddBoard(dto);
            return Ok(result);
        }

        [HttpPut(Routes.Boards.UpdateBoard)]
        public async Task<IActionResult> UpdateBoard(UpdateBoardRequest request)
        {
            var dto = new BoardDTO
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId
            };

            var result = await _boardsService.UpdateBoard(dto);

            return Ok(result);
        }

        [HttpDelete(Routes.Boards.DeleteBoard)]
        public async Task<IActionResult> DeleteBoard(BoardIdRequest request)
        {
            await _boardsService.DeleteBoard(request.ProjectId, request.Id);

            return Ok();
        }
    }
}