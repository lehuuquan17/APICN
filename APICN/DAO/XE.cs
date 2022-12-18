using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("XE")]
    public class XE
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID_XE { get; set; }

        [StringLength(50)]
        public string BKS { get; set; }

        [StringLength(50)]
        public string SeriNo { get; set; }

        [StringLength(50)]
        public string Tenchuxe { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Hangxe { get; set; }

        [StringLength(50)]
        public string Loaixe { get; set; }

        [StringLength(50)]
        public string Mauxe { get; set; }

        [StringLength(50)]
        public string EngineNo { get; set; }

        [StringLength(50)]
        public string ChasssisNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayhethan { get; set; }

        
        public virtual ICollection<BienBan> BienBans { get; set; }
    }
}

