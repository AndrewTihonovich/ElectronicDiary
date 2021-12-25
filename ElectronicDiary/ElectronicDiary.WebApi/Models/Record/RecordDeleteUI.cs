using ElectronicDiary.BLL.Records.Deleter;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordDeleteUI : IRecordDeleteUI
    {
        private IRecordDeleter _recordDeleter;

        public RecordDeleteUI(IRecordDeleter recordDeleter)
        {
            _recordDeleter = recordDeleter;
        }

        public async Task<RecordDtoUI> Delete(int Id)
        {
            var delRecord = RecordMapperUI.MapDelete(Id);
            var record = _recordDeleter.Delete(delRecord);

            return RecordMapperUI.Map(await record);
        }
    }
}
