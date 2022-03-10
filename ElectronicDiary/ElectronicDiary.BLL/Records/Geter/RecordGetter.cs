using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _db.Context.Records
                .Where(x => x.UserId == record.UserId)
                .Select(r => new RecordDto
                {
                    Text = r.Text,
                    Theme = r.Theme,
                    Id = r.Id,
                    WasCreated = r.WasCreated,
                })
                .ToListAsync();
            return result;
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
