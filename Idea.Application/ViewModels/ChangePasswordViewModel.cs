using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string CurrentPassword { get; set; } 

        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 16 characters")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 16 characters")]
        public string ConfirmPassword { get; set; } 
    }
}
