using ElectronicDiary.WebApi.Models.Record.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validations.Update
{
    public class UpdateRecordValidatorUI : IUpdateRecordValidatorUI
    {
        public Task ValidateUpdate(RecordUpdateDtoUI updateRrecord)
        {
            if (updateRrecord.Id <= 0 || updateRrecord.Id > int.MaxValue)
            {
                throw new Exception($"Id = {updateRrecord.Id} does not exist");
            }
            if (string.IsNullOrWhiteSpace(updateRrecord.UserId))
            {
                throw new ArgumentNullException("UserId can not be null or empty");
            }
            if (string.IsNullOrWhiteSpace(updateRrecord.Text))
            {
                throw new ArgumentNullException("Record text can not be null or empty");
            }
            return Task.CompletedTask;
        }
    }
}