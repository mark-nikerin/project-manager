using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces.Boards;
using ProjectManager.Services.Interfaces.DTO.Boards;
using ProjectManager.Storage;
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services.Boards
{
    public class BoardsService : BaseService, IBoardsService
    {
        public BoardsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<BoardDTO>> GetBoards(int projectId)
        {
            var boards = await _context.Boards
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return boards;
        }

        public async Task<BoardDTO> GetBoard(int projectId, int boardId)
        {
            var board = await _context.Boards
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == boardId)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            if (board == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Board with id={boardId} not found");

            return board;
        }

        public async Task<BoardDTO> AddBoard(int projectId, BoardDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, projectId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Board with title '{model.Title}' already exists in this project");

            var board = new Board
            {
                Title = model.Title,
                Description = model.Description,
                ProjectId = projectId
            };

            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();

            var addedBoard = await _context.Boards
                .AsNoTracking()
                .Where(x => x.ProjectId == board.ProjectId)
                .Where(x => x.Title == board.Title)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedBoard;
        }

        public async Task<BoardDTO> UpdateBoard(int projectId, BoardDTO model)
        {
            var board = await _context.Boards
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            if (board == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Board with id={model.Id} not found");

            if (await IsAlreadyExistsAsync(model.Title, projectId, model.Id))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Board with title '{model.Title}' already exists in this project");

            board.Title = model.Title;
            board.Description = model.Description;

            _context.Boards.Update(board);
            await _context.SaveChangesAsync();

            var result = board.ToDTO();
            return result;
        }

        public async Task DeleteBoard(int projectId, int boardId)
        {
            var board = await _context.Boards
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == boardId)
                .FirstOrDefaultAsync();

            _context.Remove(board);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, int projectId, int? id = null)
        {
            var query = _context.Boards
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