using ElectronicDiary.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Getter
{
    public interface IRecordGetter
    {
        Task<RecordDto> GetById(RecordDtoRequest record);
        Task<List<RecordDto>> GetAllAsync(RecordDtoRequest record);
    }
}
