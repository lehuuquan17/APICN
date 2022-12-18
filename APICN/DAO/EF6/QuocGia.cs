using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("QuocGia")]
    public class QuocGia:BaseObjectDataBase
    {
        [Column(TypeName = "nvarchar(100)")]
        public virtual string LoaiQuocGia { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenGoiChung { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenChinhThuc { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string MaDienThoai { get; set; }
        public virtual IList<ThanhPho> ThanhPhos { get; set; } = new List<ThanhPho>();
    }
}
