using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Create
{
    public interface ICreateRecordValidatorUI
    {
        Task ValidateCreate(RecordCreateDtoUI createRecord);
    }
}
