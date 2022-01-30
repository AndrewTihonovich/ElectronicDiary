using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
using System;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Updater
{
    public class RecordUpdater : IRecordUpdater
    {
        private IElectronicDiaryDbContext _db;
        private IRecordValidator _validator;

        public RecordUpdater(IElectronicDiaryDbContext db, IRecordValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<RecordDto> Update (RecordDtoRequest record)
        {
            await _validator.Validate(record);

            var recordDbModel = await _db.Context.Records.FindAsync(record.Id);

            if (recordDbModel == null)
            {
                throw new Exception($"Record whith Id {record.Id} not found");
            }

            if (recordDbModel.UserId == record.UserId)
            {
                recordDbModel.Text = record.Text;
                recordDbModel.Theme = record.Theme;
            }
            else 
                { throw new Exception($"Can not update record. The record is owned by another user"); }
            

            var entry = _db.Context.Records.Update(recordDbModel);

            await _db.Context.SaveChangesAsync();

            return RecordMapper.Map(entry.Entity);
        }
    }
}
