

using API_HTGT.DAO;
using API_HTGT.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using APICN.DAO.Them;
using APICN.DAO.Capnhat;
using API_HTGT.Models;
using APICN.Models.Api.ChucVu.GetChucVu;
using APICN.Models.Api.BienBan.GetBienBan;
using Microsoft.EntityFrameworkCore;
using APICN.Controllers;



namespace API_HTGT.Controllers
{
    /// <summary>
    /// Biên bản xử phạt giao thông
    /// </summary>

    public class BienBanController : BaseController
    {
        public BienBanController(MyDBcontext dBcontext) : base(dBcontext)
        {
        }

        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {

                var data = dbcontext.BienBans.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.BienBans
                    .Include(p => p.TaiKhoan)
                    .Include(p => p.Phuong)
                    .ThenInclude(p => p.huyen)
                    .ThenInclude(p => p.Tinhthanhpho)
                    .ThenInclude(p => p.QuocGiaa)
                    .Include(p => p.NguoiViPham)
                    .Include(p => p.Xe)
                    .Include(p => p.Loi)
                    
                    
                    
                    .Select(p => new
                    {
                        MaTaikhoan = p.MaTaiKhoan,
                        ID_BB = p.ID_BB,
                        Ngaylap = p.NgayLap,
                        nguoiviphon = p.NguoiViPham.Hoten,
                        NguoiViPham = p.NguoiViPham.SoDinhDanh,
                        phuong = p.Phuong.tenphuong,
                        huyen = p.Phuong.huyen.tenhuyen,
                        tinh = p.Phuong.huyen.Tinhthanhpho.tentinhthanh,
                        quocgia = p.Phuong.huyen.Tinhthanhpho.QuocGiaa.TenChinhThuc,
                        Xe = p.Xe.BKS,
                        Loi = p.Loi.Tenloi,
                        Noidungloi = p.Loi.Noidungloi,
                        mucphat = p.Loi.mucphat,
                       


                    })
                    .ToList()
                });

        }
        catch (Exception ex)
        {
            return Ok("T bat duoc loi roi");
    }
}
[HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetBienBan([FromQuery] GetBienBan request)
        {
            try
            {

                var Xe1 = await dbcontext.BienBans
                    .Where(p => p.ID_BB == request.ID_BB || p.MaNguoiViPham == request.MaNguoiViPham)
                    .FirstOrDefaultAsync();
                if (Xe1 == null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Không tìm thấy dữ liệu"
                    });
                }

                return Ok(new ApiResponse
                {
                   // Success = data.Count > 0,
                    Data = dbcontext.BienBans
                    .Include(p => p.Phuong)
                    .ThenInclude(p => p.huyen)
                    .ThenInclude(p => p.Tinhthanhpho)
                    .ThenInclude(p => p.QuocGiaa)
                    .Include(p => p.NguoiViPham)
                    .Include(p => p.Xe)
                    .Include(p => p.Loi)



                    .Select(p => new
                    {
                        ID_BB = p.ID_BB,
                        Ngaylap = p.NgayLap,
                        nguoiviphon = p.NguoiViPham.Hoten,
                        NguoiViPham = p.NguoiViPham.SoDinhDanh,
                        phuong = p.Phuong.tenphuong,
                        huyen = p.Phuong.huyen.tenhuyen,
                        tinh = p.Phuong.huyen.Tinhthanhpho.tentinhthanh,
                        quocgia = p.Phuong.huyen.Tinhthanhpho.QuocGiaa.TenChinhThuc,
                        Xe = p.Xe.BKS,
                        Loi = p.Loi.Tenloi,
                        Noidungloi = p.Loi.Noidungloi,
                        mucphat = p.Loi.mucphat,




                    })
                    .ToList()
                });
           
            }
            catch
            {

                return Ok("T bat duoc loi roi");
            }

        }
        [HttpPost, Authorize(Roles = "quanle")]

        public async Task<IActionResult> ThemBienBan([FromBody] AddBB addXE)
        {
            var xe = new BienBan()
            {

                ID_BB = Guid.NewGuid(),       
                MaXe = (Guid)addXE.MaXe,
                MaPhuong = (Guid)addXE.MaPhuong,
                MaTaiKhoan = new Guid(Request.HttpContext.User.Claims.Where(p => p.Type == "Id").FirstOrDefault().Value),  
                MaNguoiViPham = (Guid)addXE.MaNguoiViPham,
                MaLoi = (Guid)addXE.MaLoi,  
               // NgayLap = addXE.NgayLap,
                TrangThai = addXE.TrangThai,
                NoiDungViPham = addXE.NoiDungViPham,
                YKienNguoiViPham = addXE.YKienNguoiViPham,



            };
            await dbcontext.BienBans.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID_BB:guid}")]
        public async Task<IActionResult> CapnhatBienBan([FromRoute] Guid ID_BB, CapnhatBB capnhatXE)
        {
            var Xe = await dbcontext.BienBans.FindAsync(ID_BB);
            if (Xe != null)
            {
                
               
                Xe.MaXe = capnhatXE.MaXe;
                Xe.MaPhuong = capnhatXE.MaPhuong;
                Xe.MaTaiKhoan = capnhatXE.MaTaiKhoan;//DateTime.Parse(capnhatXE.MaTaiKhoan.ToString());
                Xe.MaNguoiViPham = capnhatXE.MaNguoiViPham;
                Xe.MaLoi = capnhatXE.MaLoi;
             
                Xe.NgayLap = DateTime.Parse(capnhatXE.NgayLap.ToString());
             
                Xe.TrangThai = capnhatXE.TrangThai;
                
                Xe.NoiDungViPham = capnhatXE.NoiDungViPham;


                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }


        
        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaBienBan([FromQuery] GetBienBan request)
        {
            var Xe = await dbcontext.BienBans.FindAsync(request.ID_BB);
            if (Xe != null)
            {
                dbcontext.Remove(Xe);
                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();

        }
    }
}
