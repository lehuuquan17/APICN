using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("BienBan")]
    public class BienBan: BaseObjectDataBase
    {
        [ForeignKey("Phuong")]
        public Guid? MaPhuong { get; set; }
        [ForeignKey("TaiKhoan")]
        public Guid? MaTaiKhoan { get; set; }
        [ForeignKey("Xe")]
        public Guid? MaXe { get; set; }
        [ForeignKey("NguoiViPham")]
        public Guid? MaNguoiViPham { get; set; }
        [ForeignKey("Loi")]
        public Guid? MaLoi { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? MaBienBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string? AnhBienBan { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string TrangThai { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string BienSoXe { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string NoiDungViPham { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string YKienNguoiViPham { get; set; }

        public virtual Loi Loi { get; set; }
        public virtual NguoiViPham NguoiViPham { get; set; }
        public virtual Xe Xe { get; set; }
        public virtual Phuong Phuong { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
