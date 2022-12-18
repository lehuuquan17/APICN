using System.ComponentModel.DataAnnotations;

namespace API_HTGT.DAO
{
    public class RefreshToken
    {
        [Key]
        public Guid ID_RefreshToken { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
