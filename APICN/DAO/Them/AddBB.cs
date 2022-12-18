using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace APICN.DAO.Them
{
    public class AddBB
    {


      

        public Guid? MaPhuong { get; set; }
        public Guid? MaTaiKhoan { get; set; }
        public Guid? MaXe { get; set; }
        public Guid? MaNguoiViPham { get; set; }
        public Guid? MaLoi { get; set; }
   

        //[Column(TypeName = "date")]
        //public DateTime? NgayLap { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(500)")]
        public string TrangThai { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string NoiDungViPham { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string YKienNguoiViPham { get; set; }



        public int? idphuong { get; set; }


    }
}
