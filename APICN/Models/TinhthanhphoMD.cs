using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{
    public class TinhthanhphoMD
    {




        public Guid Id_tinh { get; set; }

        public int? id_quocgia { get; set; }

        
        public string tentinhthanh { get; set; }

       
    }
}

