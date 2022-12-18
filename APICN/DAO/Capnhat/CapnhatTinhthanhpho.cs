using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Capnhat
{
    public class CapnhatTinhthanhpho

    {


        public int? id_quocgia { get; set; }

        [StringLength(50)]
        public string tentinhthanh { get; set; }
    }
}
