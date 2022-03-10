using ElectronicDiary.BLL.Records.Getter;
using ElectronicDiary.WebApi.Models.Record.Dto.Response;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using ElectronicDiary.WebApi.Models.Record.Mapper;
using ElectronicDiary.WebApi.Models.Record.Validation.Create;
using ElectronicDiary.WebApi.Models.Record.Validation.Get;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record
{
    public class RecordGetUI : IRecordGetUI
    {
        private IRecordGetter _recordGetter;
        private IGetRecordValidatorUI _getValidator;


        public RecordGetUI(IRecordGetter recordGetUI, IGetRecordValidatorUI getValidator)
        {
            _recordGetter = recordGetUI;
            _getValidator = getValidator;
        }

        public async Task<RecordDtoGetOneUI> GetOne(int Id)
        {
            await _getValidator.ValidateGetOne(Id);
            var getRecord = RecordMapperUI.MapGetOne(Id);
            var record = _recordGetter.GetById(getRecord);

            return RecordMapperUI.MapOne(await record);
        }

        public async Task<List<RecordDtoGetOneUI>> GetAll(string userId)
        {
            await _getValidator.ValidateGetAll(userId);
            var getRecord = RecordMapperUI.MapGetAll(userId);
            var records = _recordGetter.GetAllAsync(getRecord);

            return RecordMapperUI.MapList( await records);
        }
    }
}
