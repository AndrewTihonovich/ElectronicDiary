using ElectronicDiary.BLL.Models;
using System;
using System.Threading.Tasks;

namespace ElectronicDiary.BLL.Records
{
    public class RecordValidator : IRecordValidator
    {
        public Task Validate(RecordDtoRequest record)
        {
            if (record == null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(record.Text))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(record.Theme))
            {
                throw new ArgumentNullException();
            }

            return Task.CompletedTask;
        }
    }
}
