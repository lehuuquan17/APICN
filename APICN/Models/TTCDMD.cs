using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class TTCDMD
    {
       

        
        public Guid ID { get; set; }

        public int? SoDinhDanh { get; set; }


        public string Hoten { get; set; }

  
        public string GioiTinh { get; set; }

        public string QuocTich { get; set; }

      
        public string Quequan { get; set; }

    
        public string DiaChi { get; set; }

     
        public string Dacdiemnhandang { get; set; }

       
        public DateTime? NgayCap { get; set; }

     
        public DateTime? NgayHetHan { get; set; }

    }
}

