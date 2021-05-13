using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Boards;
using ProjectManager.Services.Interfaces.DTO.Projects;

namespace ProjectManager.Services.Interfaces
{
    public interface IBoardsService
    {
        Task<IReadOnlyCollection<BoardDTO>> GetBoards(int projectId);
        Task<BoardDTO> GetBoard(int projectId, int boardId);
        Task<BoardDTO> AddBoard(int projectId, BoardDTO model);
        Task<BoardDTO> UpdateBoard(int projectId, BoardDTO model);
        Task DeleteBoard(int projectId, int boardId);
    }
}