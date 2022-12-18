using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("LoiVP")]
    public class LoiVP
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoiVP()
        {
            BienBans = new HashSet<BienBan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id_loi { get; set; }

        [StringLength(50)]
        public string Tenloi { get; set; }

        [StringLength(200)]
        public string Noidungloi { get; set; }

        [StringLength(50)]
        public string mucphat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BienBan> BienBans { get; set; }
    }
}

