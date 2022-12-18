
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("QuocGiaa")]
    public class QuocGiaa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID_quocgia { get; set; } = Guid.NewGuid();
        [Column(TypeName = "nvarchar(100)")]
        public virtual string LoaiQuocGia { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenGoiChung { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenChinhThuc { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string MaDienThoai { get; set; }
        public virtual IList<Tinhthanhpho> Tinhthanhphos { get; set; } = new List<Tinhthanhpho>();
    }
}

