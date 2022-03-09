using System;

namespace ElectronicDiary.BLL.Models
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public DateTime? WasCreated { get; set; }
    }
}
