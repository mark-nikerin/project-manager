namespace ProjectManager.Models.Comments.Requests
{
    public class AddCommentRequest
    {
        public string Text { get; set; }

        public int AuthorId { get; set; }
    }
}