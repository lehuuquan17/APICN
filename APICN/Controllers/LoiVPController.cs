using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.Them;
using APICN.Models.Api.Loivipham.GetLoivp;
using APICN.Models.Api.Nguoidung.GetUser;
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
    /// Bảng lỗi vi phạm giao thông
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoiVPController : Controller
    {
        private readonly MyDBcontext dbcontext;

        public LoiVPController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.LoiVPs.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.LoiVPs.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetLoiVP([FromQuery] Getloivipham request)
        {
            try
            {

                var Xe1 = await dbcontext.LoiVPs
                    .Where(p => p.Id_loi == request.Id_loi || p.Tenloi == request.Tenloi)
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
        public async Task<IActionResult> Themloivp([FromBody] AddLVP addXE)
        {
            var xe = new LoiVP()
            {
                Id_loi = Guid.NewGuid(),
                Tenloi = addXE.Tenloi,
                Noidungloi = addXE.Noidungloi,
                mucphat = addXE.mucphat,



            };
            await dbcontext.LoiVPs.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{Id_loi:guid}")]
        public async Task<IActionResult> CapnhatloiVP([FromRoute] Guid Id_loi, CapnhatLVP capnhatXE)
        {
            var Xe = await dbcontext.LoiVPs.FindAsync(Id_loi);
            if (Xe != null)
            {
                Xe.Tenloi = capnhatXE.Tenloi;
                Xe.Noidungloi = capnhatXE.Noidungloi;
                Xe.mucphat = capnhatXE.mucphat;

                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }


        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaLoiVP([FromQuery] Getloivipham request)
        {
            var Xe = await dbcontext.LoiVPs.FindAsync(request.Id_loi);
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
