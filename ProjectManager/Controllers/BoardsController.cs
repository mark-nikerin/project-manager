﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Boards.Requests;
using ProjectManager.Services.Interfaces;
using ProjectManager.Services.Interfaces.DTO.Boards;
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
        public async Task<IActionResult> GetBoard(int projectId, int id)
        {
            var result = await _boardsService.GetBoard(projectId, id);
            return Ok(result);
        }

        [HttpPost(Routes.Boards.AddBoard)]
        public async Task<IActionResult> AddBoard(int projectId, AddBoardRequest request)
        {
            var dto = new BoardDTO
            {
                Title = request.Title,
                Description = request.Description
            };

            var result = await _boardsService.AddBoard(projectId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Boards.UpdateBoard)]
        public async Task<IActionResult> UpdateBoard(int projectId, int id, UpdateBoardRequest request)
        {
            var dto = new BoardDTO
            {
                Id = id,
                Title = request.Title,
                Description = request.Description
            };

            var result = await _boardsService.UpdateBoard(projectId, dto);

            return Ok(result);
        }

        [HttpDelete(Routes.Boards.DeleteBoard)]
        public async Task<IActionResult> DeleteBoard(int projectId, int id)
        {
            await _boardsService.DeleteBoard(projectId, id);

            return Ok();
        }
    }
}