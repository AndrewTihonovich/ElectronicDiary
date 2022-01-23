using ElectronicDiary.BLL.Models;
using ElectronicDiary.BLL.Records.Creater;
using ElectronicDiary.DAL;
using System;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Deleter
{
    public class RecordDeleter : IRecordDeleter
    {
        private IElectronicDiaryDbContext _db;
        private IRecordValidator _validator;

        public RecordDeleter(IElectronicDiaryDbContext db, IRecordValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<RecordDto> Delete (RecordDtoRequest record)
        {
            var recordDbModel = RecordMapper.MapUpdate(record);
            recordDbModel = await _db.Context.Records.FindAsync(recordDbModel.Id);

            if (recordDbModel == null)
            {
                throw new Exception($"Record whith Id {record.Id} not found");
            }

            var entry =  _db.Context.Records.Remove(recordDbModel);

            await _db.Context.SaveChangesAsync();

            return RecordMapper.Map(entry.Entity);
        }
    }
}
