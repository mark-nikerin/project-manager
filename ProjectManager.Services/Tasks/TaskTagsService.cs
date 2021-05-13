using ProjectManager.Services.Interfaces.Tasks;
using ProjectManager.Storage;

namespace ProjectManager.Services.Tasks
{
    public class TaskTagsService : BaseService, ITaskTagsService
    {
        public TaskTagsService(ProjectManagerContext context) : base(context)
        {
        }
    }
}