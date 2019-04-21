using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personal.Domain;
using Personal.Domain.Models;
using Personal.ViewModels.Login;

namespace Personal.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        
        public LoginController(
            DataContext dataContext,
            UserManager<ApplicationIdentityUser> userManager,
            SignInManager<ApplicationIdentityUser> signInManager)
            : base(dataContext)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _signInManager.SignOutAsync();
            var user = await _userManager.FindByEmailAsync(model.Email);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            return Ok(new LoginResult
            {
                Success = result.Succeeded
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword([FromBody]UpdatePassword model)
        {
            var result = new UpdatePasswordResult { Success = false };
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (!await _userManager.HasPasswordAsync(user))
            {
                result.Success = (await _userManager.AddPasswordAsync(user, model.NewPassword)).Succeeded;
            }
            else
            {
                if (!string.Equals(model.Password, model.ConfirmPassword))
                    return Ok(result);
                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    result.Success = (await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword)).Succeeded;
                    return Ok(result);
                }
            }

            return Ok(result);
        }
    }
}