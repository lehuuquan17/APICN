using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("User")]
    public class User
    {
        
        [Key]             
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string UserName { get; set; }
        [ForeignKey("ChucVu")]
        public Guid? Ma_ChuVu { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VarChar")]
        public string PassWord { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? TrangThai { get; set; }
        public virtual ChucVu ChucVu { get; set; }

        public virtual IList<BienBan> BienBans { get; set; } = new List<BienBan>();
    }
}

