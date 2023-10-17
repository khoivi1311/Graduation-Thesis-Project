using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class UserTokens
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public Users User { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ExpiredDate { get; set;}
    }
}
