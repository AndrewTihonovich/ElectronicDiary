using ElectronicDiary.BLL.Models;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Deleter
{
    public interface IRecordDeleter
    {
        Task<RecordDto> Delete (RecordDtoRequest record);
    }
}
