using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("TaiKhoan")]
    public class TaiKhoan:BaseObjectDataBase
    {
        [ForeignKey("ChucVu")]
        public Guid MaChucVu { get; set; } 
        public virtual ChucVu ChucVu { get; set; }
    }
}
