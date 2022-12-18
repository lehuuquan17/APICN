using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Capnhat
{
    public class Capnhatphuong
    {


        [StringLength(50)]
        public string tenphuong { get; set; }

        public int? id_huyen { get; set; }
    }
}
