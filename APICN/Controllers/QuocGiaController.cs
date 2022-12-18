using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.Them;
using APICN.Models.Api.QuocGia.GetQuocGia;
using APICN.Models.Api.Tinhthanhpho.GetTTP;
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
    /// Bảng Quốc gia 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuocGiaController : Controller
        {
            private readonly MyDBcontext dbcontext;

            public QuocGiaController(MyDBcontext dBcontext)
            {
            this.dbcontext = dBcontext;
            }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.QuocGiaas.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.QuocGiaas.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetQuocGia([FromQuery] GetQuocGiacs request)
        {
            try
            {

                var Xe1 = await dbcontext.QuocGiaas
                    .Where(p => p.ID_quocgia == request.ID_quocgia || p.TenChinhThuc == request.TenChinhThuc)
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
            public async Task<IActionResult> ThemQuocGia([FromBody] AddQuocGia addXE)
            {
                var xe = new QuocGiaa()
                {
                    ID_quocgia = Guid.NewGuid(),
                    LoaiQuocGia = addXE.LoaiQuocGia,
                    TenGoiChung = addXE.TenGoiChung,
                    TenChinhThuc = addXE.TenChinhThuc,

                    MaDienThoai = addXE.MaDienThoai,



                };
                await dbcontext.QuocGiaas.AddAsync(xe);
                await dbcontext.SaveChangesAsync();
                return Ok();


            }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID_QuocGia:guid}")]

        public async Task<IActionResult> CapnhatQuocGia([FromRoute] Guid ID_QuocGia, CapnhatQuocGias capnhatXE)
        {
            try {
                var Xe = await dbcontext.QuocGiaas.FindAsync(ID_QuocGia);
                if (Xe != null)
                {
                    Xe.LoaiQuocGia = capnhatXE.LoaiQuocGia;
                    Xe.TenGoiChung = capnhatXE.TenGoiChung;
                    Xe.TenChinhThuc = capnhatXE.TenChinhThuc;

                    Xe.MaDienThoai = capnhatXE.MaDienThoai;


                    await dbcontext.SaveChangesAsync();
                    return Ok(Xe);
                }
                return NotFound();
            }catch (Exception ex) {
                return Ok("Sai ID quoc Gia");
            }
            }
        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaQuocGia([FromQuery] GetQuocGiacs request)
        {
            var Xe = await dbcontext.QuocGiaas.FindAsync(request.ID_quocgia);
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

