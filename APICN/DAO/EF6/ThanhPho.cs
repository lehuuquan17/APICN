using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    [Table("ThanhPho")]
    public class ThanhPho : BaseObjectDataBase
    {
        [ForeignKey("QuocGia")]
        public Guid MaQuocGia { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string Ten { get; set; }
        public virtual QuocGia QuocGia { get; set; }
        public virtual IList<huyen> Huyens { get; set; } = new List<huyen>();
    }
}
