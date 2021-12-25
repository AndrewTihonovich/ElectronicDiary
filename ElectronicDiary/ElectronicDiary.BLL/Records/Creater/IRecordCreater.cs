using ElectronicDiary.BLL.Models;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Creater
{
    public interface IRecordCreater
    {
        Task<RecordDto> Create (RecordDtoRequest record);
    }
}
