using ElectronicDiary.BLL.Records.Updater;
using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using ElectronicDiary.WebApi.Models.Record.Validations.Update;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordUpdateUI : IRecordUpdateUI
    {
        private IRecordUpdater _recordUpdater;
        private IUpdateRecordValidatorUI _updateValidator;

        public RecordUpdateUI(IRecordUpdater recordUpdater, IUpdateRecordValidatorUI updateValidator)
        {
            _recordUpdater = recordUpdater;
            _updateValidator = updateValidator;
        }

        public async Task<RecordDtoUI> Update(RecordUpdateDtoUI updateRrecord)
        {
            await _updateValidator.ValidateUpdate(updateRrecord);
            var newRecord = RecordMapperUI.MapUpdate(updateRrecord);
            var record = _recordUpdater.Update(newRecord);

            return RecordMapperUI.Map(await record);
        }
    }
}
