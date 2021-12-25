using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Interfaces
{
    public interface IRecordCreateUI
    {
        Task<RecordDtoUI> Create (RecordCreateDtoUI record);
    }
}
