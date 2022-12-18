using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.DAO
{
    [Table("ChucVu")]
    public class ChucVu
    {


        [Key]

        public Guid ID_ChucVu { get; set; } = Guid.NewGuid();


        [StringLength(50)]
        public string Ten_ChucVu { get; set; }

        
        public virtual IList<User> Users { get; set; } = new List<User>();
    }
}
