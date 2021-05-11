using ProjectManager.Storage;

namespace ProjectManager.Services
{
    public class BaseService
    {
        protected readonly ProjectManagerContext _context;

        protected BaseService(ProjectManagerContext context)
        {
            _context = context;
        }
    }
}