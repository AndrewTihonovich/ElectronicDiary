using System;

namespace ElectronicDiary.WebApi.Models.Record.Dto.Response
{
    public class RecordDtoGetOneUI
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public DateTime? WasCreated { get; set; }
    }
}
