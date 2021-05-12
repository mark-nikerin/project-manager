using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Storage.Migrations
{
    public partial class AddDefaultEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("TaskTypes",
                new[]
                {
                    "Id",
                    "Title",
                    "Description",
                    "ProjectId"
                },
                new[]
                {
                    "int",
                    "nvarchar(100)",
                    "nvarchar(max)",
                    "int"
                },
                new object[,]
                {
                    {1, "Bug", "Something that needs fixing", null},
                    {2, "Feature", "New functionality or improvement", null},
                    {3, "Story", "Summary of the requirements or requests from the end-user perspective", null}
                });

            migrationBuilder.InsertData("TaskStatuses",
                new[]
                {
                    "Id",
                    "Title",
                    "ProjectId"
                },
                new[]
                {
                    "int",
                    "nvarchar(100)",
                    "int"
                },
                new object[,]
                {
                    {1, "To Do", null},
                    {2, "In progress", null},
                    {3, "In review", null},
                    {4, "Done", null},
                    {5, "Won`t do", null}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "TaskTypes",
                new[]
                {
                    "Id",
                    "Title",
                    "Description",
                    "ProjectId"
                },
                new[]
                {
                    "int",
                    "nvarchar(100)",
                    "nvarchar(max)",
                    "int"
                });

            migrationBuilder.DeleteData(
                "TaskStatuses",
                new[]
                {
                    "Id",
                    "Title",
                    "Description",
                    "ProjectId"
                },
                new[]
                {
                    "int",
                    "nvarchar(100)",
                    "nvarchar(max)",
                    "int"
                });

        }
    }
}
