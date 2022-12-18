using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("ChucVu")]
    public class ChucVu : BaseObjectDataBase
    {

        [Column(TypeName = "NvarChar(100)")]
        public virtual string TenChucVu { get; set; }
        public virtual IList<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();  
    }
}
