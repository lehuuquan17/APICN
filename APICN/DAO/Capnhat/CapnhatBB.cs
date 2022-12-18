using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace APICN.DAO.Capnhat
{
    public class CapnhatBB
    {

        public Guid? ID_Nguoivipham { get; set; }

        public Guid? id_nguoilapBB { get; set; }

        public Guid? Maxe { get; set; }

        [ForeignKey("Phuong")]
        public Guid MaPhuong { get; set; }
        [ForeignKey("TaiKhoan")]
        public Guid MaTaiKhoan { get; set; }
        [ForeignKey("Xe")]
        public Guid MaXe { get; set; }
        [ForeignKey("NguoiViPham")]
        public Guid MaNguoiViPham { get; set; }
        [ForeignKey("Loi")]
        public Guid MaLoi { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string MaBienBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string AnhBienBan { get; set; }
        [Column(TypeName = "nvarchar(500)")]

        public string TrangThai { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string BienSoXe { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string NoiDungViPham { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string YKienNguoiViPham { get; set; }



        public int? idphuong { get; set; }


    }
}
