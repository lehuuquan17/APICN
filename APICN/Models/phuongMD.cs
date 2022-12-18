using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{
    public class phuongMD
    {
        
        public Guid ID_phuong { get; set; }

        public string tenphuong { get; set; }

        public int? id_huyen { get; set; }

     
    }
}

