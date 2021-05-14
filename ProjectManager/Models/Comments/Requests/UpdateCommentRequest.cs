namespace ProjectManager.Models.Comments.Requests
{
    public class UpdateCommentRequest
    {
        public string Text { get; set; }

        public int AuthorId { get; set; }
    }
}