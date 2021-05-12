using ProjectManager.Services.Interfaces.DTO.Projects;
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
                Description = board.Description,
                ProjectId = board.ProjectId
            };
        }
    }
}