using ElectronicDiary.BLL.Models;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Updater
{
    public interface IRecordUpdater
    {
        Task<RecordDto> Update (RecordDtoRequest record);
    }
}
