using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Delete
{
    public interface IDeleteRecordValidatorUI
    {
        Task ValidateDelete(int id);
    }
}
