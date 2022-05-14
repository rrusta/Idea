using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 30 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 30 characters")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public bool AcceptNewsEmails { get; set; } 

        public bool AcceptedTerms { get; set; }
    }
}
