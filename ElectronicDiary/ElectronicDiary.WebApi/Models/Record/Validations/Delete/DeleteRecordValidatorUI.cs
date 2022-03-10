using System;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Delete
{
    public class DeleteRecordValidatorUI : IDeleteRecordValidatorUI
    {
        public Task ValidateDelete(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new IndexOutOfRangeException ($"Id = {id} does not exist");
            }
            return Task.CompletedTask;
        }
    }
}
