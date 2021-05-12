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

        public static class Boards
        {
            public const string GetBoards = "api/projects/{projectId:int}/boards";
            public const string AddBoard = "api/projects/{projectId:int}/boards";
            public const string GetBoard = "api/projects/{projectId:int}/boards/{id:int}";
            public const string DeleteBoard = "api/projects/{projectId:int}/boards/{id:int}";
            public const string UpdateBoard = "api/projects/{projectId:int}/boards/{id:int}";
        }

        public static class Iterations
        {
            public const string GetIterations = "api/projects/{projectId:int}/iterations";
            public const string AddIteration = "api/projects/{projectId:int}/iterations";
            public const string GetIteration = "api/projects/{projectId:int}/iterations/{id:int}";
            public const string DeleteIteration = "api/projects/{projectId:int}/iterations/{id:int}";
            public const string UpdateIteration = "api/projects/{projectId:int}/iterations/{id:int}";
        }

        public static class Tasks
        {
            public static class IterationTasks
            {
                public const string GetTasks = "api/iterations/{iterationId:int}/tasks";
                public const string AddTask = "api/iterations/{iterationId:int}/tasks";
                public const string GetTask = "api/iterations/{iterationId:int}/tasks/{id:int}";
                public const string DeleteTask = "api/iterations/{iterationId:int}/tasks/{id:int}";
                public const string UpdateTask = "api/iterations/{iterationId:int}/tasks/{id:int}";
            }

            public static class BoardTasks
            {
                public const string GetTasks = "api/boards/{boardId:int}/tasks";
                public const string AddTask = "api/boards/{boardId:int}/tasks";
                public const string GetTask = "api/boards/{boardId:int}/tasks/{id:int}";
                public const string DeleteTask = "api/boards/{boardId:int}/tasks/{id:int}";
                public const string UpdateTask = "api/boards/{boardId:int}/tasks/{id:int}";
            }

            public static class Comments
            {
                public const string GetComments = "api/tasks/{taskId:int}/comments";
                public const string AddComment = "api/tasks/{taskId:int}/comments";
                public const string DeleteComment = "api/tasks/{taskId:int}/comments/{id:int}";
                public const string UpdateComment = "api/tasks/{taskId:int}/comments/{id:int}";
            }

            public static class Tags
            {
                public const string GetTags = "api/projects/{projectId:int}/tasks/tags";
                public const string AddTag = "api/projects/{projectId:int}/tasks/tags";
                public const string GetTag = "api/projects/{projectId:int}/tasks/tags/{id:int}";
                public const string DeleteTag = "api/projects/{projectId:int}/tasks/tags/{id:int}";
                public const string UpdateTag = "api/projects/{projectId:int}/tasks/tags/{id:int}";
            }

            public static class Types
            {
                public const string GetTags = "api/projects/{id:int}/tasks/types";
                public const string AddTag = "api/projects/{id:int}/tasks/types";
                public const string GetTag = "api/projects/{projectId:int}/tasks/types/{id:int}";
                public const string DeleteTag = "api/projects/{projectId:int}/tasks/types/{id:int}";
                public const string UpdateTag = "api/projects/{projectId:int}/tasks/types/{id:int}";
            }

            public static class Statuses
            {
                public const string GetTags = "api/projects/{id:int}/tasks/statuses";
                public const string AddTag = "api/projects/{id:int}/tasks/statuses";
                public const string GetTag = "api/projects/{projectId:int}/tasks/statuses/{id:int}";
                public const string DeleteTag = "api/projects/{projectId:int}/tasks/statuses/{id:int}";
                public const string UpdateTag = "api/projects/{projectId:int}/tasks/statuses/{id:int}";
            }
        }

        public static class WorkTimeRecords
        {
            public const string GetRecords = "api/work/records";
            public const string AddRecord = "api/work/records";
            public const string DeleteRecord = "api/work/records/{id:int}";
            public const string UpdateRecord = "api/work/records/{id:int}";
        }

        public static class Auth
        {
            public const string Register = "api/auth/register";
            public const string Login = "api/auth/login";
        }
    }
}