using System;

namespace ProjectManager.Services.Interfaces.DTO.Comments
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public int AuthorId { get; set; }

        public int TaskId { get; set; }
    }
}