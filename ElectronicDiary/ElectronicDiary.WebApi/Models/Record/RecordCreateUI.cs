using ElectronicDiary.BLL.Records.Creater;
using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordCreateUI : IRecordCreateUI
    {
        private IRecordCreater _recordCreater;

        public RecordCreateUI(IRecordCreater recordCreater)
        {
            _recordCreater = recordCreater;
        }

        public async Task<RecordDtoUI> Create(RecordCreateDtoUI createRecord)
        {
            var newRecord = RecordMapperUI.MapCreate(createRecord);
            var record = _recordCreater.Create(newRecord);

            return RecordMapperUI.Map(await record);
        }
    }
}
