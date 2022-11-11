using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ZeusERP.MasterApi.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<SysUser> _userManager;
        private RoleManager<SysUserRole> _roleManager;
        private SignInManager<SysUser> _signinManager;
        private IConfiguration _config;

        public AccountController(
            UserManager<SysUser> userManager,
            RoleManager<SysUserRole> roleManager,
            SignInManager<SysUser> signinManager,
            IConfiguration config
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto content)
        {

            SignInResult result = _signinManager.PasswordSignInAsync(content.Username, content.Password, content.Remember, false).Result;
            if(result.Succeeded)
            {
                var tokenString = GenerateJSONWebToken(new SysUser { UserName = content.Username });

                return Ok(new { token = tokenString });
            }
            return Forbid(JsonConvert.SerializeObject("Unapproved!"));
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto content)
        {
            var user = await _userManager.FindByNameAsync(content.Username);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, content.Password);

            if(result.Succeeded)
            {
                return Ok(new { message = "Success!", success = true });
            }
            return BadRequest(new { message = "Failure", success = false });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto content)
        {

            var user = new SysUser
            {
                UserName = content.Username
            };
            IdentityResult result = _userManager.CreateAsync(user, content.Password).Result;
            if(result.Succeeded)
            {
                if(!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    SysUserRole role = new SysUserRole
                    {
                        Name = "Admin"
                    };

                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                    var addToRoleResult = _userManager.AddToRoleAsync(user, "Admin").Result;

                    if(!addToRoleResult.Succeeded)
                    {
                        return BadRequest(JsonConvert.SerializeObject("Role cannot be created!"));
                    }
                }

                return Ok(JsonConvert.SerializeObject("User was created successfully!"));
            }
            return BadRequest(JsonConvert.SerializeObject("There was a problem with user generation."));
        }

        private string GenerateJSONWebToken(SysUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users;
            return Ok(JsonConvert.SerializeObject(users));
        }
        [HttpGet("CheckRoleByUsername")]
        public async Task<IActionResult> CheckRoleByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            bool isInRole = await _userManager.IsInRoleAsync(user, "Admin");
            return Ok(isInRole.ToString());
        }
    }
}
