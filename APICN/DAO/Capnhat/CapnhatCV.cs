using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Capnhat
{
    public class CapnhatCV
    {

        [StringLength(50)]
        public string Ten_ChucVu { get; set; }
        [StringLength(50)]
        public string Ma_ChucVu { get; set; }
    }
}
