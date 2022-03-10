using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using System;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Create
{
    public class CreateRecordValidatorUI : ICreateRecordValidatorUI
    {
        public Task ValidateCreate(RecordCreateDtoUI createRecord)
        {
            if (string.IsNullOrWhiteSpace(createRecord.UserId))
            {
                throw new ArgumentNullException("UserId can not be null or empty");
            }
            if (string.IsNullOrWhiteSpace(createRecord.Text))
            {
                throw new ArgumentNullException("Record text can not be null or empty");
            }
            return Task.CompletedTask;
        }
    }
}
