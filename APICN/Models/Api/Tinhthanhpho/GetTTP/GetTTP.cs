using System.ComponentModel.DataAnnotations;

namespace APICN.Models.Api.Tinhthanhpho.GetTTP
{
    public class GetTTP
    {
        public Guid ID_quocgia { get; set; }

        [Required]
        [StringLength(50)]
        public string tentinhthanh { get; set; }
    }
}
