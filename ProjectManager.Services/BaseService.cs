using ProjectManager.Storage;

namespace ProjectManager.Services
{
    public class BaseService
    {
        protected readonly ProjectManagerContext _context;

        public BaseService(ProjectManagerContext context)
        {
            _context = context;
        }
    }
}