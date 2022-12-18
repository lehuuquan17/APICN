using System.ComponentModel.DataAnnotations;

namespace APICN.Models.Api.Phuong.GetPhuong
{
    public class GetPhuong
    {
        public Guid id_huyen { get; set; }

        [Required]
        [StringLength(50)]
        public string tenphuong { get; set; }
    }
}
