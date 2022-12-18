using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("Phuong")]
    public class Phuong : BaseObjectDataBase
    {
        [ForeignKey("ThanhPho")]
        public Guid MaThanhPho { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string Ten { get; set; }
        public virtual ThanhPho ThanhPho { get; set; }
    }
}
