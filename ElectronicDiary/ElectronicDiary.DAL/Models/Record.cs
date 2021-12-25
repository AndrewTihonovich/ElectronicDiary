
namespace ElectronicDiary.DAL.Models
{
    public class Record : TimeLabel
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
