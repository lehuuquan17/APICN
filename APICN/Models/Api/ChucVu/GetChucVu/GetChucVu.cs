using System.ComponentModel.DataAnnotations;

namespace APICN.Models.Api.ChucVu.GetChucVu
{
    public class GetChucVu
    {
        public Guid ID_ChucVu { get; set; }

        [StringLength(50)]
        public string Ma_ChucVu { get; set; }

    }
}
