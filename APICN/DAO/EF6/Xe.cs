using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("Xe")]
    public class Xe : BaseObjectDataBase
    {
        [Column(TypeName = "nvarchar(100)")]
        public string BienSoXe { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string SoGiayToDangKyXe { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TenChuXe { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string DiaChi { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string HangXe { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string LoaiXe { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string MauXe { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string SoKhung { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string SoMay { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayMua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
    }
}
