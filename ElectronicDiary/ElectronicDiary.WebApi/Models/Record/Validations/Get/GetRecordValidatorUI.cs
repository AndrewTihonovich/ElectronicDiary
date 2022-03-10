using System;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Record.Validation.Get
{
    public class GetRecordValidatorUI : IGetRecordValidatorUI
    {
        public Task ValidateGetAll(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("Value userId cannot be null or empty");
            }
            return Task.CompletedTask;
        }

        public Task ValidateGetOne(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new IndexOutOfRangeException ($"Id = {id} does not exist");
            }
            return Task.CompletedTask;
        }
    }
}
