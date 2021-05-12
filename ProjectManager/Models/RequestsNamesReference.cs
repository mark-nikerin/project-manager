using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Models
{
    public class RequestsNamesReference
    {
        public const string Id = "id";
        public const string ProjectId = "projectId";
    }

    public class IdRequest
    {
        [FromRoute(Name = RequestsNamesReference.Id)]
        public int Id { get; set; }
    }
}