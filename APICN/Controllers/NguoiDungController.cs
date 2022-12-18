using API_HTGT.Context;
using API_HTGT.DAO;
using API_HTGT.Models;
using APICN.Models.Api.Nguoidung.GetUser;
using APICN.Models.Api.Phuong.GetPhuong;
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
    /// Bảng người dùng
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NguoiDungController : Controller
    {

        private readonly MyDBcontext dbcontext;

        public NguoiDungController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }
        
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = dbcontext.Users.ToList();

                return Ok(new ApiResponse
                {
                    Success = data.Count > 0,
                    Data = dbcontext.Users.ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok("T bat duoc loi roi");
            }
        }
        [HttpGet, Authorize(Roles = "quanle")]
        public async Task<IActionResult> GetNguoidung([FromQuery] GetUser request)
        {
            try
            {

                var Xe1 = await dbcontext.Users
                    .Where(p => p.ID == request.ID || p.UserName == request.UserName)
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
        [HttpPost]
        public async Task<IActionResult> ThemUser([FromBody] UserMD addXE)
        {
            var xe = new User()
            {
                ID = Guid.NewGuid(),
                HOTEN = addXE.HOTEN,
                UserName = addXE.UserName,
                Ma_ChuVu = addXE.Ma_ChuVu, 
                PassWord = addXE.PassWord,
                Email = addXE.Email,
                TrangThai = addXE.TrangThai,
               
               
             



            };
            await dbcontext.Users.AddAsync(xe);
            await dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpPut, Authorize(Roles = "quanle")]
        [Route("{ID:guid}")]
        public async Task<IActionResult> CapnhatNguoidung([FromRoute] Guid ID, UserMD capnhatXE)
        {
            var Xe = await dbcontext.Users.FindAsync(ID);
            if (Xe != null)
            {
                Xe.HOTEN = capnhatXE.HOTEN;
                Xe.UserName = capnhatXE.UserName;
                Xe.PassWord = capnhatXE.PassWord;
                Xe.Email = capnhatXE.Email;
                Xe.TrangThai = capnhatXE.TrangThai;
              


                await dbcontext.SaveChangesAsync();
                return Ok(Xe);
            }
            return NotFound();
        }


        [HttpDelete, Authorize(Roles = "quanle")]
        
        public async Task<IActionResult> XoaNguoiDung([FromQuery] GetUser request)
        {
            var Xe = await dbcontext.Users.FindAsync(request.ID);
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
