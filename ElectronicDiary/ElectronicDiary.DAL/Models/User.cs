using System.Collections.Generic;

namespace ElectronicDiary.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
