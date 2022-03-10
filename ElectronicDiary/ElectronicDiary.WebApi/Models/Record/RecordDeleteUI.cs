using ElectronicDiary.BLL.Records.Deleter;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using ElectronicDiary.WebApi.Models.Record.Validation.Delete;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordDeleteUI : IRecordDeleteUI
    {
        private IRecordDeleter _recordDeleter;
        private IDeleteRecordValidatorUI _deleteValidator;

        public RecordDeleteUI(IRecordDeleter recordDeleter, IDeleteRecordValidatorUI deleteValidator)
        {
            _recordDeleter = recordDeleter;
            _deleteValidator = deleteValidator;
        }

        public async Task<RecordDtoUI> Delete(int Id)
        {
            await _deleteValidator.ValidateDelete(Id);
            var delRecord = RecordMapperUI.MapDelete(Id);
            var record = _recordDeleter.Delete(delRecord);

            return RecordMapperUI.Map(await record);
        }
    }
}
