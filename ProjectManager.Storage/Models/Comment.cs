using System;

namespace ProjectManager.Storage.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public int AuthorId { get; set; }

        public int TaskId { get; set; }

        public virtual User Author { get; set; }

        public virtual Task Task { get; set; }

    }
}