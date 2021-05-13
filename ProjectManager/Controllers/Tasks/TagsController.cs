using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Tasks
{
    public class TagsController : ControllerBase
    {
        private readonly ITaskTagsService _tagsService;

        public TagsController(ITaskTagsService tagsService)
        {
            _tagsService = tagsService;
        } 

    }
}