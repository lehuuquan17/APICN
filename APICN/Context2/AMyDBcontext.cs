//using API_HTGT.DAO;
//using APICN.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Microsoft.Extensions.Options;
//using System;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Diagnostics;
//using System.Linq;

//namespace API_HTGT.Context
//{//MyDBcontext
//    public class MyDBcontext : DbContext, IMyDBcontext
//    {
//        public MyDBcontext(DbContextOptions options): base(options)
//        {

//        }
//        public virtual DbSet<BienBan> BienBans { get; set; }
//        public virtual DbSet<ChucVu> ChucVus { get; set; }
//        public virtual DbSet<huyen> Huyens { get; set; }
//        public virtual DbSet<id_nn> id_nn { get; set; }
//        public virtual DbSet<LoiVP> LoiVPs { get; set; }
//        public virtual DbSet<phuonghuyen> phuongs { get; set; }
//        public virtual DbSet<QuocGiaa> QuocGiaas { get; set; }
//        public virtual DbSet<Tinhthanhpho> Tinhthanhphoes { get; set; }
//        public virtual DbSet<TTCD> TTCDs { get; set; }
//        public virtual DbSet<User> Users { get; set; }
//        public virtual DbSet<XE> XEs { get; set; }

//        public virtual Task<int> SaveChangesAsync()
//        {
//            return base.SaveChangesAsync();
//        }
//        public override EntityEntry Remove(object entity)
//        {
//            return base.Remove(entity);
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.LogTo((log) => { Debug.WriteLine(log); });
//            base.OnConfiguring(optionsBuilder);
//        }




//    }
//}
