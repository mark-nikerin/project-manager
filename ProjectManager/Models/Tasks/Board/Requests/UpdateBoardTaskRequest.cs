using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Tasks.Board.Requests
{
    public class UpdateBoardTaskRequest : BaseUpdateTaskRequest
    {
        [FromRoute(Name = RequestsNamesReference.BoardId)]
        public int BoardId { get; set; }
    }
}