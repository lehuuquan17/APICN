using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICN.DAO.Capnhat
{
    public class CapnhatQuocGias
    {
        [Column(TypeName = "nvarchar(100)")]
        public virtual string LoaiQuocGia { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenGoiChung { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string TenChinhThuc { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string MaDienThoai { get; set; }
    }
}

