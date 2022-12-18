using APICN.DAO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("phuong")]
    public class phuonghuyen
    {

        [Key]
        public Guid ID_phuong { get; set; } = Guid.NewGuid();

        [ForeignKey("huyen")]
        public Guid id_huyen { get; set; }

        [Required]
        [StringLength(50)]
        public string tenphuong { get; set; }



        public virtual huyen huyen { get; set; }

    }
}

