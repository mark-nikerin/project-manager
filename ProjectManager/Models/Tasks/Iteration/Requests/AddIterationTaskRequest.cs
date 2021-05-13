using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models.Tasks.Iteration.Requests
{
    public class AddIterationTaskRequest : BaseAddTaskRequest
    {
        [FromRoute(Name = RequestsNamesReference.IterationId)]
        public int IterationId { get; set; }
    }
}