using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Boards.Requests
{
    public class AddBoardRequest
    {
        [FromRoute(Name = RequestsNamesReference.ProjectId)]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}