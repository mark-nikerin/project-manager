using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces.DTO.WorkTimeRecords;
using ProjectManager.Services.Interfaces.WorkTimeRecords;
using ProjectManager.Storage;
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services.WorkTimeRecords
{
    public class WorkTimeRecordsService : BaseService, IWorkTimeRecordsService
    {
        public WorkTimeRecordsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<WorkTimeRecordDTO>> GetRecords(int userId)
        {
            var records = await _context.WorkTimeRecords
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return records;
        }

        public async Task<WorkTimeRecordDTO> AddRecord(WorkTimeRecordDTO model)
        {
            var record = new WorkTimeRecord
            {
                Date = model.Date,
                Description = model.Description,
                Hours = model.Hours,
                UserId = model.UserId,
                ProjectId = model.ProjectId,
                TaskId = model.TaskId
            };

            await _context.WorkTimeRecords.AddAsync(record);
            await _context.SaveChangesAsync();

            var addedTag = await _context.WorkTimeRecords
                .AsNoTracking()
                .Where(x => x.Date == record.Date)
                .Where(x => x.TaskId == record.TaskId)
                .Where(x => x.UserId == record.UserId)
                .Where(x => x.Description == record.Description)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedTag;
        }

        public async Task<WorkTimeRecordDTO> UpdateRecord(int recordId, WorkTimeRecordDTO model)
        {
            var record = await _context.WorkTimeRecords
                .Where(x => x.Id == recordId)
                .FirstOrDefaultAsync();

            if (record == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Record with id={recordId} not found");

            record.Date = model.Date;
            record.Description = model.Description;
            record.Hours = model.Hours;
            record.TaskId = model.TaskId;
            record.ProjectId = model.ProjectId;

            _context.WorkTimeRecords.Update(record);
            await _context.SaveChangesAsync();

            var result = record.ToDTO();
            return result;
        }

        public async Task DeleteRecord(int recordId)
        {
            var record = await _context.WorkTimeRecords
                .Where(x => x.Id == recordId)
                .FirstOrDefaultAsync();

            if (record != null)
            {
                _context.WorkTimeRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}