using System.ComponentModel.DataAnnotations;

namespace API_HTGT.DAO
{
    public class UserDto
    {
        [Key]
        public Guid ID_UserDto { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
       

    }
}
