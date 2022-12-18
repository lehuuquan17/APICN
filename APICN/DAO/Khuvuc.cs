using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace API_HTGT.DAO
{
    [Table("Khuvuc")]
    public  partial class Khuvuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khuvuc()
        {
            BienBans = new HashSet<BienBan>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID_Khuvuc { get; set; }

        [StringLength(50)]
        public string TenKhuVuc { get; set; }

        [StringLength(50)]
        public string Motakhuvuc { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BienBan> BienBans { get; set; }
    }
}
