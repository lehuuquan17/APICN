namespace API_HTGT.DAO
{
    using API_HTGT.DAO;
    using APICN.DAO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    [Table("BienBan")]
    public partial class BienBan
    {


        [Key]
        public Guid ID_BB { get; set; } = Guid.NewGuid();

  
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

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; } = DateTime.Now;
        [Column(TypeName = "varchar(2000)")]     
        public string? TrangThai { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? NoiDungViPham { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string? YKienNguoiViPham { get; set; }




        

        public virtual LoiVP Loi { get; set; }
        public virtual TTCD NguoiViPham { get; set; }
        public virtual XE Xe { get; set; }

        public virtual User TaiKhoan { get; set; }
        public virtual phuonghuyen Phuong { get; set; }
    }
}
