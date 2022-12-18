using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Capnhat
{
    public class Capnhathuyenthanh
    {

        [StringLength(50)]
        public string tenhuyen { get; set; }

        public int? id_tinh { get; set; }
    }
}
