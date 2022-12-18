using System;
using System.ComponentModel.DataAnnotations;
using API_HTGT.DAO;

namespace APICN.DAO.Capnhat
{
    public class Capnhatid_nn
    {
        [Key]
        public Guid id_user_bb { get; set; }

        public int? id_bb { get; set; }

        public int? id_user { get; set; }

        public virtual BienBan BienBan { get; set; }

        public virtual User User { get; set; }
    }
}
