using ProjectManager.Services.Interfaces.DTO.Boards;
using ProjectManager.Services.Interfaces.DTO.Comments;
using ProjectManager.Services.Interfaces.DTO.Iterations;
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

        public static IterationDTO ToDTO(this Iteration iteration)
        {
            if (iteration == null)
            {
                return null;
            }

            return new IterationDTO
            {
                Id = iteration.Id,
                Title = iteration.Title,
                Description = iteration.Description,
                StartDate = iteration.StartDate,
                EndDate = iteration.EndDate
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
                Status = task.Status.ToDTO(),
                Priority = task.Priority.ToDTO(),
                Type = task.Type.ToDTO()
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
                Status = task.Status.ToDTO(),
                Priority = task.Priority.ToDTO(),
                Type = task.Type.ToDTO(),
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate,
                DueToDate = task.DueToDate,
                ReporterId = task.ReporterId.GetValueOrDefault(),
                ParentTaskId = task.ParentTaskId
            };
        }

        public static TaskTypeDTO ToDTO(this TaskType type)
        {
            if (type == null)
            {
                return null;
            }

            return new TaskTypeDTO
            {
                Id = type.Id,
                Title = type.Title,
                Description = type.Description
            };
        }

        public static TaskStatusDTO ToDTO(this TaskStatus status)
        {
            if (status == null)
            {
                return null;
            }

            return new TaskStatusDTO
            {
                Id = status.Id,
                Title = status.Title
            };
        }

        public static TaskTagDTO ToDTO(this TaskTag tag)
        {
            if (tag == null)
            {
                return null;
            }

            return new TaskTagDTO
            {
                Id = tag.Id,
                Title = tag.Title
            };
        }

        public static CommentDTO ToDTO(this Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new CommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
                CreatedDate = comment.CreatedDate,
                UpdatedDate = comment.UpdatedDate,
                AuthorId = comment.AuthorId,
                TaskId = comment.TaskId
            };
        }
    }
}