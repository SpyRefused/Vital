using System.ComponentModel.DataAnnotations;

namespace Vital.Identity.ApiModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
