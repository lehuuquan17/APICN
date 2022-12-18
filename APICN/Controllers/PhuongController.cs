using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.EF6;
using APICN.DAO.Them;
using APICN.Models.Api.Phuong.GetPhuong;
using APICN.Models.Api.QuocGia.GetQuocGia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace API_HTGT.Controllers
{   /// <summary>
    /// Bảng người dùng
    /// </summary>

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PhuongController : Controller
        {
            private readonly MyDBcontext dbcontext;

            public PhuongController(MyDBcontext dBcontext)
            {
            this.dbcontext = dBcontext;
            }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.phuongs.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.phuongs.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetPhuong([FromQuery] GetPhuong request)
        {
            try
            {

                var Xe1 = await dbcontext.phuongs
                    .Where(p => p.id_huyen == request.id_huyen || p.tenphuong == request.tenphuong)
                    .ToListAsync();
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
            public async Task<IActionResult> ThemPhuong([FromBody] AddPhuong addXE)
            {
                var xe = new phuonghuyen()
                {
                    ID_phuong = Guid.NewGuid(),
                    tenphuong = addXE.tenphuong,
                    id_huyen = (Guid)addXE.id_huyen!,





                };
                await dbcontext.phuongs.AddAsync(xe);
                await dbcontext.SaveChangesAsync();
                return Ok();


            }
            [HttpPut, Authorize(Roles = "quanle")]
            [Route("{ID_phuong:guid}")]
        public async Task<IActionResult> CapnhatPhuong([FromForm] Guid ID_phuong, Capnhatphuong capnhatXE)
            {
                var Xe = await dbcontext.phuongs.FindAsync(ID_phuong);
                if (Xe != null)
                {
                    Xe.tenphuong = capnhatXE.tenphuong;
                   


                    await dbcontext.SaveChangesAsync();
                    return Ok(Xe);
                }
                return NotFound();
            }
            [HttpDelete, Authorize(Roles = "quanle")]

        public async Task<IActionResult> XoaPhuong([FromQuery] phuonghuyen request)
        {
            var Xe = await dbcontext.phuongs.FindAsync(request.ID_phuong);
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

