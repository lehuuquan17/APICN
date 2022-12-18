
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace API_HTGT.Models
{

    public class BienBanMD
    {
       
       
        public Guid ID_BB { get; set; }

        public int? ID_Nguoivipham { get; set; }

        public int? Id_khuvuc { get; set; }

        public int? Id_nguoilapBB { get; set; }

        public int? Maxe { get; set; }

       
        public DateTime? thoigianlap { get; set; }

    
        public string NDVPGT { get; set; }

        public string DiadiemVP { get; set; }

       
        public string TinhtrangBB { get; set; }

      
        public string DongYloi { get; set; }

      
      
    }
}
