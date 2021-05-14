using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.WorkTimeRecords.Requests;
using ProjectManager.Services.Interfaces.DTO.WorkTimeRecords;
using ProjectManager.Services.Interfaces.WorkTimeRecords;

namespace ProjectManager.Controllers.WorkTimeRecords
{
    [ApiController]
    public class WorkTimeRecordsController : ControllerBase
    {
        private readonly IWorkTimeRecordsService _workTimeRecordService;

        public WorkTimeRecordsController(IWorkTimeRecordsService workTimeRecordService)
        {
            _workTimeRecordService = workTimeRecordService;
        }

        [HttpGet(Routes.WorkTimeRecords.GetRecords)]
        public async Task<IActionResult> GetRecords()
        {
            const int userId = 1; //TODO: добавить определение id пользователя
            var result = await _workTimeRecordService.GetRecords(userId);
            return Ok(result);
        }

        [HttpPost(Routes.WorkTimeRecords.AddRecord)]
        public async Task<IActionResult> AddRecord(AddWorkTimeRecordRequest request)
        {
            var dto = new WorkTimeRecordDTO
            {
                Description = request.Description,
                Hours = request.Hours,
                Date = request.Date,
                TaskId = request.TaskId,
                ProjectId = request.ProjectId,
                UserId = 1 //TODO: добавить определение id пользователя
            };

            var result = await _workTimeRecordService.AddRecord(dto);
            return Ok(result);
        }

        [HttpPut(Routes.WorkTimeRecords.UpdateRecord)]
        public async Task<IActionResult> UpdateRecord(int id, UpdateWorkTimeRecord request)
        {
            var dto = new WorkTimeRecordDTO
            {
                Description = request.Description,
                Hours = request.Hours,
                Date = request.Date,
                TaskId = request.TaskId,
                ProjectId = request.ProjectId
            };

            var result = await _workTimeRecordService.UpdateRecord(id, dto);
            return Ok(result);
        }

        [HttpDelete(Routes.WorkTimeRecords.DeleteRecord)]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            await _workTimeRecordService.DeleteRecord(id);
            return Ok();
        }
    }
}