using System.ComponentModel.DataAnnotations;

namespace APICN.Models.Api.Loivipham.GetLoivp
{
    public class Getloivipham
    {
        public Guid Id_loi { get; set; }

        [StringLength(50)]
        public string Tenloi { get; set; }

    }
}
