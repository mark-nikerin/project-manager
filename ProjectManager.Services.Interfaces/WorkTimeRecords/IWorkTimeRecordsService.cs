using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Services.Interfaces.DTO.WorkTimeRecords;

namespace ProjectManager.Services.Interfaces.WorkTimeRecords
{
    public interface IWorkTimeRecordsService
    {
        Task<IReadOnlyCollection<WorkTimeRecordDTO>> GetRecords(int userId);
        Task<WorkTimeRecordDTO> AddRecord(WorkTimeRecordDTO model);
        Task<WorkTimeRecordDTO> UpdateRecord(int recordId, WorkTimeRecordDTO model);
        Task DeleteRecord(int recordId);
    }
}