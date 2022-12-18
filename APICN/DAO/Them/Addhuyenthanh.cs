using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class Addhuyenthanh
    {
        [Key]
        public Guid Id_huyen { get; set; }

        [StringLength(50)]
        public string tenhuyen { get; set; }

        public Guid? id_tinh { get; set; }
    }
}
