using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace APICN.DAO.Capnhat
{
    public class CapnhatTTCD
    {
        public string? SoDinhDanh { get; set; }

        [StringLength(50)]
        public string Hoten { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string QuocTich { get; set; }

        [StringLength(100)]
        public string Quequan { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Dacdiemnhandang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
    }
}
