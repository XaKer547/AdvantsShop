﻿using System.ComponentModel.DataAnnotations;

namespace AdvantShop.Domain.Models.Account
{
    public class SignInDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
