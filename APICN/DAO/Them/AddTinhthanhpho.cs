using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class AddTinhthanhpho
    {
       

        public Guid? id_quocgia { get; set; }

        [StringLength(50)]
        public string tentinhthanh { get; set; }
    }
}
