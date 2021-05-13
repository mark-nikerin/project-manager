using System;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services.Interfaces.DTO.Enums;

namespace ProjectManager.Models.Tasks.Board.Requests
{
    public class AddBoardTaskRequest : BaseAddTaskRequest
    {
        [FromRoute(Name = RequestsNamesReference.BoardId)]
        public int BoardId { get; set; }
    }
}