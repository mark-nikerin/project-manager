using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Tasks.Iteration.Requests
{
    public class IterationTaskIdRequest : IdRequest
    {
        [FromRoute(Name = RequestsNamesReference.IterationId)]
        public int IterationId { get; set; }
    }
}