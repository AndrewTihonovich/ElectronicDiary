using ElectronicDiary.BLL.Models;
using ElectronicDiary.DAL.Models;

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
                UserId = 1       
            };
        }

        public static Record MapGetById(RecordDtoRequest getOneRecord)
        {
            return new Record
            {
                Id = getOneRecord.Id,
            };
        }

        public static Record MapUpdate(RecordDtoRequest updateRecord)
        {
            return new Record
            {
                Theme = updateRecord.Theme,
                Text = updateRecord.Text,
                Id=updateRecord.Id,
                UserId = 1       
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
    }
}
