using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.Them;
using APICN.Models.Api.TTCD.GetTTCD;
using APICN.Models.Api.XE.GetXe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace API_HTGT.Controllers
{
    /// <summary>
    /// Bảng thông tin công dân 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TTCDController : Controller
    {
        private readonly MyDBcontext dbcontext;

        public TTCDController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.TTCDs.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.TTCDs.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetCongDan([FromQuery] GetTTCDRequest request)
        {
            try
            {

                var Xe1 = await dbcontext.TTCDs
                    .Where(p => p.ID == request.ID || p.SoDinhDanh == request.SoDinhDanh)
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
                    Success = true,
                    Data = Xe1
                });
            }
            catch
            {

                return Ok("T bat duoc loi roi");
            }

        }
        [HttpPost, Authorize(Roles = "quanle")]
        public async Task<IActionResult> ThemCongDan([FromBody] AddTTCD addXE)
        {
            var xe = new TTCD()
            {
                ID = Guid.NewGuid(),
                SoDinhDanh = addXE.SoDinhDanh,
                Hoten = addXE.Hoten,
                GioiTinh = addXE.GioiTinh,
                QuocTich = addXE.QuocTich,
                Quequan = addXE.Quequan,
                DiaChi = addXE.DiaChi,
                Dacdiemnhandang = addXE.Dacdiemnhandang,
                NgayCap = DateTime.Parse(addXE.NgayCap.ToString()),
            NgayHetHan = DateTime.Parse(addXE.NgayHetHan.ToString()),



        };
            await dbcontext.TTCDs.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID:guid}")]
        public async Task<IActionResult> CapNhatCongDan([FromForm] Guid ID, CapnhatTTCD capnhatXE)
        {
            var Xe = await dbcontext.TTCDs.FindAsync(ID);
            if (Xe != null)
            {
                Xe.SoDinhDanh = capnhatXE.SoDinhDanh;
                Xe.Hoten = capnhatXE.Hoten;
                Xe.GioiTinh = capnhatXE.GioiTinh;
                Xe.QuocTich = capnhatXE.QuocTich;
                Xe.Quequan = capnhatXE.Quequan;
                Xe.DiaChi = capnhatXE.DiaChi;
                Xe.Dacdiemnhandang = capnhatXE.Dacdiemnhandang;
                Xe.NgayCap = DateTime.Parse(capnhatXE.NgayCap.ToString());
                Xe.NgayHetHan = DateTime.Parse(capnhatXE.NgayHetHan.ToString());

                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }


        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaCongDan([FromQuery] GetTTCDRequest request)
        {
            var Xe = await dbcontext.TTCDs.FindAsync(request.ID);
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
