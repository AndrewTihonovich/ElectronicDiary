using ElectronicDiary.BLL.Models;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Getter
{
    public interface IRecordGetter
    {
        Task<RecordDto> GetById(RecordDtoRequest record);
    }
}
