using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.DAO.Capnhat;
using APICN.DAO.Them;
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
    /// Bảng thông tin xe
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class XEController : Controller
    {
        private readonly MyDBcontext dbcontext;

        public XEController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }

        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.XEs.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.XEs.ToList()
                });

            }
            catch(Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetXE([FromQuery] GetXeRequest request)
        {
            try
            {

                var Xe1 = await dbcontext.XEs
                    .Where(p => p.BKS == request.BKS || p.ID_XE == request.Id)
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

        [HttpDelete, Authorize(Roles = "quanle")]
        public async Task<IActionResult> XoaXe([FromQuery] GetXeRequest request)
        {
            var Xe = await dbcontext.XEs.FindAsync(request.Id);
            if (Xe != null)
            {
                dbcontext.Remove(Xe);
                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();

        }

        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID_XE:guid}")]

        public async Task<IActionResult> CapnhatXE([FromRoute] Guid ID_XE, CapnhatXE request)
        {
            var Xe = await dbcontext.XEs.FindAsync(ID_XE);
            if (Xe != null)
            {
                Xe.BKS = request.BKS;
                Xe.SeriNo = request.SeriNo;
                Xe.Tenchuxe = request.Tenchuxe;
                Xe.DiaChi = request.DiaChi;
                Xe.Hangxe = request.Hangxe;
                Xe.Loaixe = request.Loaixe;
                Xe.Mauxe = request.Mauxe;
                Xe.EngineNo = request.EngineNo;
                Xe.ChasssisNo = request.ChasssisNo;
                Xe.NgayMua = DateTime.Parse(request.NgayMua.ToString());
                Xe.Ngayhethan = DateTime.Parse(request.Ngayhethan.ToString());

                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }

        [HttpPost, Authorize(Roles = "quanle")]
        public async Task<IActionResult> AddXes([FromBody] AddXE request)
        {
            var xe = new XE()
            {
                ID_XE = Guid.NewGuid(),
                BKS = request.BKS,
                SeriNo = request.SeriNo,
                Tenchuxe = request.Tenchuxe,
                DiaChi = request.DiaChi,
                Hangxe = request.Hangxe,
                Loaixe = request.Loaixe,
                Mauxe = request.Mauxe,
                EngineNo = request.EngineNo,
                ChasssisNo = request.ChasssisNo,
                NgayMua = DateTime.Parse(request.NgayMua.ToString()),
                Ngayhethan = DateTime.Parse(request.Ngayhethan.ToString()),


            };
            await dbcontext.XEs.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();

        }
    }
}
