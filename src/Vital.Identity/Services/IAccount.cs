using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vital.Identity.ApiModels.AccountViewModels;

namespace Vital.Identity
{
    public interface IAccount
    {
        Task<SignInResult> Login(LoginViewModel model, string returnUrl = null);
    }
}