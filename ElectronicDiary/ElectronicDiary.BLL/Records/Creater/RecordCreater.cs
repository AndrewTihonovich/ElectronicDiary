using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records.Creater
{
    public class RecordCreater : IRecordCreater
    {
        private IElectronicDiaryDbContext _db;
        private IRecordValidator _validator;

        public RecordCreater(IElectronicDiaryDbContext db, IRecordValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<RecordDto> Create(RecordDtoRequest record) 
        {
            await _validator.Validate(record);
            var recordDbModel = RecordMapper.MapCreate(record);
            var entry = await _db.Context.Records.AddAsync(recordDbModel);
           
            await _db.Context.SaveChangesAsync();
            
            return RecordMapper.Map(entry.Entity);
        }
    }
}
