using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class XEMD
    {
       
        
        public Guid ID_XE { get; set; }

      
        public string BKS { get; set; }

    
        public string SeriNo { get; set; }

       
        public string Tenchuxe { get; set; }

        public string DiaChi { get; set; }

       
        public string Hangxe { get; set; }

        public string Loaixe { get; set; }

        
        public string Mauxe { get; set; }

        public string EngineNo { get; set; }

        public string ChasssisNo { get; set; }

        public DateTime? NgayMua { get; set; }

        
        public DateTime? Ngayhethan { get; set; }

       
    }
}

