using System;
using System.Linq.Expressions;
using ProjectManager.Services.Interfaces.DTO.Enums;
using ProjectManager.Storage.Enums;

namespace ProjectManager.Services.Extensions
{
    public static class EnumMappingExtensions
    {
        public static ProjectTypeEnum ToDTO(this ProjectType value)
        {
            return value switch
            {
                ProjectType.Common => ProjectTypeEnum.Common,
                ProjectType.Iterative => ProjectTypeEnum.Iterative,
                _ => throw new Exception($"Unknown project type: {value}")
            };
        }

        public static ProjectType ToEntity(this ProjectTypeEnum value)
        {
            return value switch
            {
                ProjectTypeEnum.Common => ProjectType.Common,
                ProjectTypeEnum.Iterative => ProjectType.Iterative,
                _ => throw new Exception($"Unknown project type: {value}")
            };
        }

        public static TaskPriorityEnum ToDTO(this TaskPriority value)
        {
            return value switch
            {
                TaskPriority.Minor => TaskPriorityEnum.Minor,
                TaskPriority.Normal => TaskPriorityEnum.Normal,
                TaskPriority.Major => TaskPriorityEnum.Major,
                TaskPriority.Critical => TaskPriorityEnum.Critical,
                TaskPriority.Blocker => TaskPriorityEnum.Blocker,
                _ => throw new Exception($"Unknown project type: {value}")
            };
        }

        public static TaskPriority ToEntity(this TaskPriorityEnum value)
        {
            return value switch
            {
                TaskPriorityEnum.Minor => TaskPriority.Minor,
                TaskPriorityEnum.Normal => TaskPriority.Normal,
                TaskPriorityEnum.Major => TaskPriority.Major,
                TaskPriorityEnum.Critical => TaskPriority.Critical,
                TaskPriorityEnum.Blocker => TaskPriority.Blocker,
                _ => throw new Exception($"Unknown project type: {value}")
            };
        }
    }
}