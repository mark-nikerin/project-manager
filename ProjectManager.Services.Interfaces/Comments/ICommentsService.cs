using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.Comments;

namespace ProjectManager.Services.Interfaces.Comments
{
    public interface ICommentsService
    {
        Task<IReadOnlyCollection<CommentDTO>> GetComments(int taskId);
        Task<CommentDTO> AddComment(int taskId, CommentDTO model);
        Task<CommentDTO> UpdateComment(int taskId, int commentId, CommentDTO model);
        Task DeleteComment(int taskId, int commentId);
    }
}