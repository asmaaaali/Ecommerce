using Ecommerce.DAL;
using Ecommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Customer> manager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<Customer> manager, IConfiguration configuration)
        {
            this.manager = manager;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var dbCustomer = new Customer
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var result = await manager.CreateAsync(dbCustomer, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, dbCustomer.Id),
                new Claim(ClaimTypes.Role, "Customer"),
               
            };
           await manager.AddClaimsAsync(dbCustomer, claims);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> LogIn(LoginDto loginDto)
        {
            var user = await manager.FindByNameAsync(loginDto.UserName);
            if (user == null) {
                return BadRequest();
            }
            var IsAuth = await manager.CheckPasswordAsync(user, loginDto.Password);
            if (!IsAuth)
            {
                return BadRequest();
            }
            var cliams = await manager.GetClaimsAsync(user);
            var key = configuration.GetValue<string>("secretKey");
            var keyInBytes = Encoding.ASCII.GetBytes(key);
            var keyObject = new SymmetricSecurityKey(keyInBytes);
            var sC = new SigningCredentials(keyObject, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: cliams,
                signingCredentials: sC,
                expires: DateTime.UtcNow.AddMinutes(10)
                );
            var tokenHandler = new JwtSecurityTokenHandler();
           var tokenString = tokenHandler.WriteToken(token);
            var tokenDb = new TokenDto(tokenString);
            return Ok(tokenDb);
        }
    }
}
