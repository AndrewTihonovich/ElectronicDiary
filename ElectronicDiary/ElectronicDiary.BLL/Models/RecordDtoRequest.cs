﻿
namespace ElectronicDiary.BLL.Models
{
    public class RecordDtoRequest
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
