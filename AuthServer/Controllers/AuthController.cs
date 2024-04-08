using AuthServer.Dtos;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;
using SharedLib.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Controllers
{

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
    }
}
