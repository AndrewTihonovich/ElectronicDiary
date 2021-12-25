using ElectronicDiary.BLL.Models;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records
{
    public interface IRecordValidator
    {
        Task Validate(RecordDtoRequest record);
    }
}
