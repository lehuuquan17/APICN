using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class QuocGiaMD
    {
       

     
        public Guid ID_QuocGia { get; set; }

        
        public string MaQuocGia { get; set; }

     
        public string TenGoiChung { get; set; }

     
        public string TenChinhThuc { get; set; }

      
        public string LoaiQuocGia { get; set; }

       
        public string Madienthoai { get; set; }

       
    }
}

