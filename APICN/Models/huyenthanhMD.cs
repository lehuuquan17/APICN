using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class huyenthanhMD
    {


        public Guid Id_huyen { get; set; }

        public string tenhuyen { get; set; }

        public int? id_tinh { get; set; }

     
    }
}

