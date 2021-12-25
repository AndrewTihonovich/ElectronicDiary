using ElectronicDiary.BLL.Records.Updater;
using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordUpdateUI : IRecordUpdateUI
    {
        private IRecordUpdater _recordUpdater;

        public RecordUpdateUI(IRecordUpdater recordUpdater)
        {
            _recordUpdater = recordUpdater;
        }

        public async Task<RecordDtoUI> Update(RecordUpdateDtoUI updateRrecord)
        {
            var newRecord = RecordMapperUI.MapUpdate(updateRrecord);
            var record = _recordUpdater.Update(newRecord);

            return RecordMapperUI.Map(await record);
        }
    }
}
