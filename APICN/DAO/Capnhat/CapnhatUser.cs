using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.Capnhat
{
    public class CapnhatUser
    {



        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string PassWord { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string TrangThai { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CHUCVU { get; set; }
    }
}
