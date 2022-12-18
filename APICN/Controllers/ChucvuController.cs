using API_HTGT.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using API_HTGT.DAO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using APICN.DAO.Them;
using APICN.DAO.Capnhat;
using API_HTGT.Models;
using APICN.Models.Api.XE.GetXe;
using APICN.Models.Api.ChucVu.GetChucVu;

namespace API_HTGT.Controllers
{
    /// <summary>
    /// Chức vụ người dùng
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChucvuController : Controller
    {
        private readonly MyDBcontext dbcontext;

        public ChucvuController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.ChucVus.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.ChucVus.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetChucVu([FromQuery] GetChucVu request)
        {
            try
            {

                var Xe1 = await dbcontext.ChucVus
                    .Where(p => p.ID_ChucVu == request.ID_ChucVu )
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
        public async Task<IActionResult> ThemChucVu(AddCV addXE)
        {
            var xe = new ChucVu()
            {
                Ten_ChucVu = addXE.Ten_ChucVu,
            };
            await dbcontext.ChucVus.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID_ChucVu:guid}")]
        public async Task<IActionResult> CapnhatChucVu([FromRoute] Guid ID_ChucVu, CapnhatCV capnhatXE)
        {
            var Xe = await dbcontext.ChucVus.FindAsync(ID_ChucVu);
            if (Xe != null)
            {
                Xe.Ten_ChucVu = capnhatXE.Ten_ChucVu;
                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }
        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaXe([FromQuery] GetChucVu request)
        {
            var Xe = await dbcontext.ChucVus.FindAsync(request.ID_ChucVu);
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
