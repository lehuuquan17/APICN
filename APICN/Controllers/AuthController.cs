
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using API_HTGT.DAO;
using API_HTGT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API_HTGT.Context;
using APICN.DAO.Them;
using APICN.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API_HTGT.Controllers
{
    /// <summary>
    /// Xác thực tài khoản Auth
    /// </summary>
    public class AuthController : BaseController
    {
        private readonly AppSetting _appSettings;

        public AuthController(IOptionsMonitor<AppSetting> optionsMonitor,MyDBcontext dBcontext) : base(dBcontext)
        {
            _appSettings = optionsMonitor.CurrentValue;
        }

        /// <summary>
        /// Xác thực tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Validate(AddUser model)
        {
             var user = dbcontext.Users.Include(p=> p.ChucVu)
                .SingleOrDefault(p => p.UserName == model.UserName && model.PassWord == p.PassWord);
            if (user == null) //không đúng
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            //cấp token

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }

        private string GenerateToken(User nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey.ToString());

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name.ToString(), nguoiDung.UserName),
                    new Claim(ClaimTypes.Role, nguoiDung.ChucVu.Ten_ChucVu),
                    new Claim("UserName", nguoiDung.UserName.ToString()),
                    new Claim("Id", nguoiDung.ID.ToString()),

                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
