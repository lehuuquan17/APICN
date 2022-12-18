using APICN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("Tinhthanhpho")]
    public class Tinhthanhpho
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id_tinh { get; set; } = Guid.NewGuid();
        [ForeignKey("QuocGiaa")]
        public Guid? MaQuocGia { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string tentinhthanh { get; set; }
        public virtual QuocGiaa QuocGiaa { get; set; }
        public virtual IList<huyen> Huyens { get; set; } = new List<huyen>();


    }
}

