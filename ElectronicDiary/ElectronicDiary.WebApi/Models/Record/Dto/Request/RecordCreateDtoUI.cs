using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.WebApi.Models.Record.Dto.Request
{
    public class RecordCreateDtoUI
    {
        [MaxLength(64)]
        public string Theme { get; set; }

        [MaxLength(1000), Required]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
