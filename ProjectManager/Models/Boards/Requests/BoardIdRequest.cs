using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Boards.Requests
{
    public class BoardIdRequest : IdRequest
    {
        [FromRoute(Name = RequestsNamesReference.ProjectId)]
        public int ProjectId { get; set; }
    }
}