using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class LoiVPMD
    {

        public Guid Id_loi { get; set; }

        
        public string Tenloi { get; set; }

        public string Noidungloi { get; set; }

       
        public string mucphat { get; set; }

      
    }
}

