using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace API_HTGT.Models
{

    public  partial class KhuvucMD
    {
      


       
        public Guid ID_Khuvuc { get; set; }

        [StringLength(50)]
        public string TenKhuVuc { get; set; }

        [StringLength(50)]
        public string Motakhuvuc { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        
    }
}
