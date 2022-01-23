using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
using System;
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
