using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vital.Identity.ApiModels;
using Vital.Identity.ApiModels.AccountViewModels;

namespace Vital.Identity.Services
{
    public class Account : IAccount
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Account(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginViewModel model, string returnUrl = null)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }    
    }
}
