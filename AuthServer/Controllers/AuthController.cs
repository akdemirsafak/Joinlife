using AuthServer.Dtos;
using AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLib.Auth;
using SharedLib.BaseController;
using SharedLib.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace AuthServer.Controllers
{
    [Authorize(LocalApi.PolicyName)] //Claim bazlı yetkilendirme işlemi gerçekleşiyor.
    public class AuthController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupModel)
        {

            ApplicationUser user= new ApplicationUser()
            {
                UserName = signupModel.UserName,
                Email = signupModel.Email
            };
            var identityResult= await _userManager.CreateAsync(user,signupModel.Password);
            if (!identityResult.Succeeded)
            {
                return CreateActionResult(AppResponse<NoContentResponse>.Fail(identityResult.Errors.Select(x => x.Description).ToList(), 400));
            }
            return CreateActionResult(AppResponse<NoContentResponse>.Success(201));
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim= User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null)
            {
                return BadRequest();
            }
            var user= await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
            {
                return BadRequest();
            }
            var userDto= new GetUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(userDto);
        }
    }
}
