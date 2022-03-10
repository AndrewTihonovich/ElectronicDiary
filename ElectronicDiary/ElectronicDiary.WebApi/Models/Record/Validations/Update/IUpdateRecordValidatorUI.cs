using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validations.Update
{
    public interface IUpdateRecordValidatorUI
    {
        Task ValidateUpdate(RecordUpdateDtoUI updateRrecord);
    }
}
