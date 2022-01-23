using ElectronicDiary.BLL.Records.Getter;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using System;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordGetUI : IRecordGetUI
    {
        private IRecordGetter _recordGetter;

        public RecordGetUI(IRecordGetter recordGetUI)
        {
            _recordGetter = recordGetUI;
        }

        public async Task<RecordDtoGetOneUI> GetOne(int Id)
        {
            if (Id<=0 || Id>int.MaxValue)
            {
                throw new Exception($"Id = {Id} does not exist");
            }
            var getRecord = RecordMapperUI.MapGetOne(Id);
            var record = _recordGetter.GetById(getRecord);

            return RecordMapperUI.MapOne(await record);
        }
    }
}
