﻿using System.ComponentModel.DataAnnotations;

namespace Vital.Identity.ApiModels.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
