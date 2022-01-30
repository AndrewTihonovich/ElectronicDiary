
namespace ElectronicDiary.DAL.Models
{
    public class Record : TimeLabel
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
