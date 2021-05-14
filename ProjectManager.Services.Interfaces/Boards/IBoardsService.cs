using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Boards;

namespace ProjectManager.Services.Interfaces.Boards
{
    public interface IBoardsService
    {
        Task<IReadOnlyCollection<BoardDTO>> GetBoards(int projectId);
        Task<BoardDTO> GetBoard(int projectId, int boardId);
        Task<BoardDTO> AddBoard(int projectId, BoardDTO model);
        Task<BoardDTO> UpdateBoard(int projectId, int boardId, BoardDTO model);
        Task DeleteBoard(int projectId, int boardId);
    }
}