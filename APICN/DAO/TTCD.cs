using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("TTCD")]
    public class TTCD
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        [Column(TypeName = "nvarchar(3000)")]
        public string SoDinhDanh { get; set; }

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

        [StringLength(200)]
        public string Dacdiemnhandang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
        
        public virtual ICollection<BienBan> BienBans { get; set; }
    }
}

