namespace ProjectManager
{
    public static class Routes
    {
        public static class Projects
        {
            public const string GetProjects = "api/projects";
            public const string AddProject = "api/projects";
            public const string GetProject = "api/projects/{id:int}";
            public const string DeleteProject = "api/projects/{id:int}";
            public const string UpdateProject = "api/projects/{id:int}";
        }
    }
}