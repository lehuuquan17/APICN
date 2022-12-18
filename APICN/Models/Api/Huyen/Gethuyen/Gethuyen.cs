using System.ComponentModel.DataAnnotations;

namespace APICN.Models.Api.Huyen.Gethuyen
{
    public class Gethuyen
    {
        public Guid ID_TinhThanhPho { get; set; }

        [Required]
        [StringLength(50)]
        public string tenhuyen { get; set; }
    }
}
