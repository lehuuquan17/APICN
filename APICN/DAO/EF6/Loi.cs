using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("Loi")]
    public class Loi: BaseObjectDataBase
    {

        [Column(TypeName = "nvarchar(100)")]
        public string Tenloi { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Noidungloi { get; set; }

        public decimal MucPhat { get; set; }
    }
}
