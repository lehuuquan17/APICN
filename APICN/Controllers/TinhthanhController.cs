using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.Them;
using APICN.Models.Api.Tinhthanhpho.GetTTP;
using APICN.Models.Api.TTCD.GetTTCD;
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
    /// Bảng Tỉnh thành 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TinhthanhController : Controller
        {
            private readonly MyDBcontext dbcontext;

            public TinhthanhController(MyDBcontext dBcontext)
            {
            this.dbcontext = dBcontext;
            }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.Tinhthanhphoes.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.Tinhthanhphoes.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetTinhThanh([FromQuery] GetTTP request)
        {
            try
            {

                var Xe1 = await dbcontext.Tinhthanhphoes
                    .Where(p => p.MaQuocGia == request.ID_quocgia || p.tentinhthanh == request.tentinhthanh)
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
            public async Task<IActionResult> ThemTinhThanh([FromBody] AddTinhthanhpho addXE)
            {
                var xe = new Tinhthanhpho()
                {
                    id_tinh = Guid.NewGuid(),
                    
                    tentinhthanh = addXE.tentinhthanh,
                    MaQuocGia = (Guid)addXE.id_quocgia,



                };
                await dbcontext.Tinhthanhphoes.AddAsync(xe);
                await dbcontext.SaveChangesAsync();
                return Ok();


            }
            [HttpPut, Authorize(Roles = "quanle")]
            [Route("{Id_tinh:guid}")]
        public async Task<IActionResult> CapNhatTinhThanh([FromRoute] Guid Id_tinh, CapnhatTinhthanhpho capnhatXE)
            {
                var Xe = await dbcontext.Tinhthanhphoes.FindAsync(Id_tinh);
                if (Xe != null)
                {
                   
                    Xe.tentinhthanh = capnhatXE.tentinhthanh;


                    await dbcontext.SaveChangesAsync();
                    return Ok(Xe);
                }
                return NotFound();
            }
        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaTinhThanh([FromQuery] Tinhthanhpho request)
        {
            var Xe = await dbcontext.Tinhthanhphoes.FindAsync(request.id_tinh);
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

