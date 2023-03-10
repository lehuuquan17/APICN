using System.ComponentModel.DataAnnotations;

namespace API_HTGT.DAO
{
    public class UserMDL
    {

        [Key]
        public Guid ID_UserMDL { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}
