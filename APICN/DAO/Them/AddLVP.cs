using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class AddLVP
    {
        [StringLength(50)]
        public string Tenloi { get; set; }

        [StringLength(200)]
        public string Noidungloi { get; set; }

        [StringLength(50)]
        public string mucphat { get; set; }
    }
}
