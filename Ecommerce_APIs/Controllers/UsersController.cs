using Ecommerce.DAL;
using Ecommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Customer> manager;

        public UsersController(UserManager<Customer> manager)
        {
            this.manager = manager;
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
    }
}
