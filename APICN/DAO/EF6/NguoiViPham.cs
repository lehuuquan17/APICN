using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("NguoiViPham")]
    public class NguoiViPham : BaseObjectDataBase
    {

        public int? SoDinhDanh { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Hoten { get; set; }

        /// <summary>
        /// true: Name
        /// false: nu
        /// null: khong xac dinh
        /// </summary>
        public bool? GioiTinh { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string QuocTich { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Quequan { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DiaChi { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Dacdiemnhandang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
    }
}
