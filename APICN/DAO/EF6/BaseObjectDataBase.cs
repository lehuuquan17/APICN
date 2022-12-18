using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.EF6
{
    public class BaseObjectDataBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Ma { get; set; } = Guid.NewGuid();
    }
}
