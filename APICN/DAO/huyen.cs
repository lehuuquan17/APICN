using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_HTGT.DAO;

namespace APICN.DAO
{
    [Table("huyen")]
    public class huyen
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id_huyen { get; set; } = Guid.NewGuid();
        [ForeignKey("Tinhthanhpho")]
        public Guid? id_tinh { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string tenhuyen { get; set; }



        public virtual Tinhthanhpho Tinhthanhpho { get; set; }
        public virtual IList<phuonghuyen> phuongs { get; set; } = new List<phuonghuyen>();
    }
}

