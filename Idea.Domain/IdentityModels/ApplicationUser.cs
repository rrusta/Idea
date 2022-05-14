using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserTypeId { get; set; }
        public bool AcceptedTerms { get; set; }
        public bool? AcceptNewsEmails { get; set; }
    }
}
