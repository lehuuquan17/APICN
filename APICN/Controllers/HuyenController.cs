using API_HTGT.Context;
using API_HTGT.Models;
using APICN.DAO;
using APICN.DAO.Them;
using APICN.Models.Api.Huyen.Gethuyen;
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
    /// Bảng huyện
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HuyenController : Controller
    {
      
            private readonly MyDBcontext dbcontext;
        
            public HuyenController(MyDBcontext dBcontext)
            {
            this.dbcontext = dBcontext;
            }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.Huyens.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.Huyens.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Gethuyen([FromQuery] Gethuyen request)
        {
            try
            {

                var Xe1 = await dbcontext.Huyens
                    .Where(p => p.id_tinh == request.ID_TinhThanhPho || p.tenhuyen == request.tenhuyen)
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
            public async Task<IActionResult> ThemHuyen(Addhuyenthanh addXE)
            {
                var xe = new huyen()
                {
                    id_huyen = Guid.NewGuid(),
                    tenhuyen = addXE.tenhuyen,
                    id_tinh = addXE.id_tinh,




                };
                await dbcontext.Huyens.AddAsync(xe);
                await dbcontext.SaveChangesAsync();
                return Ok();


            }
            [HttpPut, Authorize(Roles = "quanle")]
            [Route("{Id_huyen:guid}")]
            public async Task<IActionResult> Capnhathuyen([FromRoute] Guid Id_huyen,huyen capnhatXE)
            {
                var Xe = await dbcontext.Huyens.FindAsync(Id_huyen);
                if (Xe != null)
                {
                    Xe.tenhuyen = capnhatXE.tenhuyen;
                    Xe.id_tinh = capnhatXE.id_tinh;



                await dbcontext.SaveChangesAsync();
                    return Ok(Xe);
                }
                return NotFound();
            }
            [HttpDelete, Authorize(Roles = "quanle")]

        public async Task<IActionResult> Xoahuyen([FromQuery] huyen request)
        {
            var Xe = await dbcontext.Huyens.FindAsync(request.id_huyen);
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

