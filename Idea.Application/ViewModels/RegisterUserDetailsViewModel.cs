using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Application.ViewModels
{
    public class RegisterUserDetailsViewModel
    {
        public string UserId { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public bool AcceptNewsEmails { get; set; }

        public bool AcceptedTerms { get; set; }
    }
}
