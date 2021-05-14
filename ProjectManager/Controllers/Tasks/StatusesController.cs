using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services.Interfaces.Tasks;

namespace ProjectManager.Controllers.Tasks
{
    public class StatusesController : ControllerBase
    {
        private readonly ITaskStatusesService _statusesService;

        public StatusesController(ITaskStatusesService statusesService)
        {
            _statusesService = statusesService;
        }



    }
}