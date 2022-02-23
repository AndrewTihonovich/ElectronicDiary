using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL.Models;
using System.Collections.Generic;

namespace ElectronicDiary.BLL.Records
{
    class RecordMapper
    {
        public static Record MapCreate(RecordDtoRequest createRecord)
        {
            return new Record
            {
                Theme = createRecord.Theme,
                Text = createRecord.Text,
                UserId = createRecord.UserId     
            };
        }

        public static Record MapGetById(RecordDtoRequest getOneRecord)
        {
            return new Record
            {
                Id = getOneRecord.Id,
            };
        }

        public static Record MapGetByUserId(RecordDtoRequest getOneRecord)
        {
            return new Record
            {
                UserId = getOneRecord.UserId,
            };
        }

        public static Record MapUpdate(RecordDtoRequest updateRecord)
        {
            return new Record
            {
                Theme = updateRecord.Theme,
                Text = updateRecord.Text,
                Id=updateRecord.Id,
                UserId=updateRecord.UserId
            };
        }

        public static Record MapDelete(RecordDtoRequest deleteRecord)
        {
            return new Record
            {
                Id = deleteRecord.Id,
            };
        }

        public static RecordDto Map(Record record)
        {
            return new RecordDto
            {
                Id = record.Id,
                Text = record.Text,
                Theme = record.Theme,
            };
        }

        public static List<RecordDto> MapList(List<Record> records)
        {
            var result = new List<RecordDto>();
            foreach (var item in records)
            {
                result.Add(new RecordDto
                {
                    Id = item.Id,
                    Text = item.Text,
                    Theme = item.Theme,
                });
            }
            return result;
        }
    }
}
