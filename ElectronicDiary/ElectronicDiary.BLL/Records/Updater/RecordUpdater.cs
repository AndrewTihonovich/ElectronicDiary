using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
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
            var recordDbModel = RecordMapper.MapUpdate(record);
            var entry = _db.Context.Records.Update(recordDbModel);
            
            await _db.Context.SaveChangesAsync();

            return RecordMapper.Map(entry.Entity);
        }
    }
}
