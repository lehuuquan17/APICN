//using APICN.DAO.EF6;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;

//namespace APICN.Context2
//{
//    public class EF6DBContext : DbContext
//    {
//        public EF6DBContext(DbContextOptions options) : base(options)
//        {

//        }
//        public virtual DbSet<BienBan> BienBans { get; set; }
//        public virtual DbSet<ChucVu> ChucVus { get; set; }
//        public virtual DbSet<Loi> Lois { get; set; }
//        public virtual DbSet<NguoiViPham> NguoiViPhams { get; set; }
//        public virtual DbSet<Phuong> Phuongs { get; set; }
//        public virtual DbSet<QuocGia> QuocGias { get; set; }
//        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
//        public virtual DbSet<ThanhPho> ThanhPhos { get; set; }
//        public virtual DbSet<Xe> Xes { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.LogTo((log) => { Debug.WriteLine(log); });
//            base.OnConfiguring(optionsBuilder);
//        }
//    }
//}
