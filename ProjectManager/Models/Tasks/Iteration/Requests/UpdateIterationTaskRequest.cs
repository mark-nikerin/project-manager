using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Tasks.Iteration.Requests
{
    public class UpdateIterationTaskRequest : BaseUpdateTaskRequest
    {
        [FromRoute(Name = RequestsNamesReference.IterationId)]
        public int IterationId { get; set; }
    }
}