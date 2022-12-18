using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HTGT.Models
{

    public class UserMD
    {




       
        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string PassWord { get; set; }
        public Guid Ma_ChuVu { get; set; }
        [Required]
        [StringLength(100)]

        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string TrangThai { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CHUCVU { get; set; }
    }
}

