using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Comments.Requests;
using ProjectManager.Services.Interfaces.Comments;
using ProjectManager.Services.Interfaces.DTO.Comments;

namespace ProjectManager.Controllers.Projects.Tasks.Comments
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet(Routes.Tasks.Comments.GetComments)]
        public async Task<IActionResult> GetTypes(int taskId)
        {
            var result = await _commentsService.GetComments(taskId);
            return Ok(result);
        }

        [HttpPost(Routes.Tasks.Comments.AddComment)]
        public async Task<IActionResult> AddType(int taskId, AddCommentRequest request)
        {
            var dto = new CommentDTO
            {
                Text = request.Text,
                AuthorId = request.AuthorId
            };

            var result = await _commentsService.AddComment(taskId, dto);
            return Ok(result);
        }

        [HttpPut(Routes.Tasks.Comments.UpdateComment)]
        public async Task<IActionResult> UpdateType(int taskId, int id, UpdateCommentRequest request)
        {
            var dto = new CommentDTO
            {
                Text = request.Text,
                AuthorId = request.AuthorId
            };

            var result = await _commentsService.UpdateComment(taskId, id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.Tasks.Comments.DeleteComment)]
        public async Task<IActionResult> DeleteType(int taskId, int id)
        {
            await _commentsService.DeleteComment(taskId, id);
            return Ok();
        }

    }
}