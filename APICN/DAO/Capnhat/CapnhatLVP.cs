using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Capnhat
{
    public class CapnhatLVP
    {
        [StringLength(50)]
        public string Tenloi { get; set; }

        [StringLength(200)]
        public string Noidungloi { get; set; }

        [StringLength(50)]
        public string mucphat { get; set; }
    }
}
