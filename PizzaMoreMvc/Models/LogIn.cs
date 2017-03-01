using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LogIn
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public bool IsActive { get; set; }
    }
}
