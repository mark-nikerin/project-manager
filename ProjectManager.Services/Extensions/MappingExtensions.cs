using ProjectManager.Services.Interfaces.DTO.Boards;
using ProjectManager.Services.Interfaces.DTO.Projects;
using ProjectManager.Services.Interfaces.DTO.Tasks;
using ProjectManager.Storage.Models;

namespace ProjectManager.Services.Extensions
{
    public static class MappingExtensions
    {
        public static ProjectDTO ToDTO(this Project project)
        {
            if (project == null)
            {
                return null;
            }

            return new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Prefix = project.Prefix,
                CreatedDate = project.CreatedDate,
                UpdatedDate = project.UpdatedDate,
                Type = project.Type.ToDTO()
            };
        }

        public static BoardDTO ToDTO(this Board board)
        {
            if (board == null)
            {
                return null;
            }

            return new BoardDTO
            {
                Id = board.Id,
                Title = board.Title,
                Description = board.Description
            };
        }

        public static TaskDTO ToDTO(this Task task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                AssigneeId = task.AssigneeId,
                StatusId = task.StatusId,
                Priority = task.Priority.ToDTO(),
                TypeId = task.TypeId
            };
        }

        public static TaskDetailsDTO ToDetailsDTO(this Task task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskDetailsDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssigneeId = task.AssigneeId,
                StatusId = task.StatusId,
                Priority = task.Priority.ToDTO(),
                TypeId = task.TypeId,
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate,
                DueToDate = task.DueToDate,
                ReporterId = task.ReporterId.GetValueOrDefault(),
                ParentTaskId= task.ParentTaskId,
            };
        }
    }
}