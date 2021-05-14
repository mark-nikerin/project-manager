using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces.Comments;
using ProjectManager.Services.Interfaces.DTO.Comments;
using ProjectManager.Storage;
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services.Comments
{
    public class CommentsService : BaseService, ICommentsService
    {
        public CommentsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<CommentDTO>> GetComments(int taskId)
        {
            var comments = await _context.Comments
                .AsNoTracking()
                .Where(x => x.TaskId == taskId)
                .Select(x => x.ToDTO())
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();

            return comments;
        }

        public async Task<CommentDTO> AddComment(int taskId, CommentDTO model)
        {
            var currentDateTime = DateTimeOffset.UtcNow;

            var comment = new Comment
            {
                Text = model.Text,
                AuthorId = model.AuthorId,
                TaskId = taskId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            var addedType = await _context.Comments
                .AsNoTracking()
                .Where(x => x.TaskId == comment.TaskId)
                .Where(x => x.Text == comment.Text)
                .Where(x => x.CreatedDate == comment.CreatedDate)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedType;
        }

        public async Task<CommentDTO> UpdateComment(int taskId, int commentId, CommentDTO model)
        {
            var comment = await _context.Comments
                .Where(x => x.TaskId == taskId)
                .Where(x => x.Id == commentId)
                .FirstOrDefaultAsync();

            if (comment == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Comment with id={model.Id} not found");

            comment.Text = model.Text;
            comment.UpdatedDate = DateTimeOffset.UtcNow;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            var result = comment.ToDTO();
            return result;
        }

        public async Task DeleteComment(int taskId, int commentId)
        {
            var comment = await _context.Comments
                .Where(x => x.TaskId == taskId)
                .Where(x => x.Id == commentId)
                .FirstOrDefaultAsync();

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}