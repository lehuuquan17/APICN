using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class AddPhuong
    {
        [Key]
        public Guid ID_phuong { get; set; }

        [StringLength(50)]
        public string tenphuong { get; set; }

        public Guid? id_huyen { get; set; }
    }
}
