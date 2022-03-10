using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Get
{
    public interface IGetRecordValidatorUI
    {
        Task ValidateGetOne(int id);
        Task ValidateGetAll(string userId);
    }
}
