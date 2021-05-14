using System;

namespace ProjectManager.Models.Iterations.Requests
{
    public class AddIterationRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}