using System;
using System.ComponentModel.DataAnnotations;

namespace APICN.DAO.Them
{
    public class Addid_nn
    {
        [Key]
        public Guid id_user_bb { get; set; }

        public int? id_bb { get; set; }

        public int? id_user { get; set; }


    }
}
