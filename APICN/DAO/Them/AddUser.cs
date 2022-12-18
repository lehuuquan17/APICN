using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class AddUser
    {

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string PassWord { get; set; }
    }
}
