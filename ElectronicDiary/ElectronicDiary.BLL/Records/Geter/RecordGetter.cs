using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
using ElectronicDiary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Getter
{
    public class RecordGetter : IRecordGetter
    {
        private IElectronicDiaryDbContext _db;

        public RecordGetter(IElectronicDiaryDbContext db)
        {
            _db = db;
        }

        public async Task<List<RecordDto>> GetAllAsync(RecordDtoRequest record)
        {
            var recordDbModel = RecordMapper.MapGetByUserId(record);

            var result = new List<Record>();
            var  records = _db.Context.Records;
            await foreach (var item in records)
            {
                if (item.UserId == record.UserId)
                {
                    result.Add(new Record
                    {
                        Text = item.Text,
                        Theme = item.Theme,
                        Id = item.Id
                    });
                }
            }
            return RecordMapper.MapList(result);
        }

        public async Task<RecordDto> GetById(RecordDtoRequest record)
        {
            var recordDbModel = RecordMapper.MapGetById(record);
            var entry = await _db.Context.Records.FindAsync(recordDbModel.Id);

            if (entry==null)
            {
                throw new Exception($"Record whith Id {recordDbModel.Id} not found");
            }
            return RecordMapper.Map(entry);
        }
    }
}
