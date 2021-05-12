using System;
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
    }
}