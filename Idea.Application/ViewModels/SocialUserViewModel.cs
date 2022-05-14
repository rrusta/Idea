using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class SocialUserViewModel
    {
        public string Provider { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public int? UserTypeId { get; set; }
        public bool? AcceptedTerms { get; set; }
        public bool? AcceptNewsEmails { get; set; }
    }
}
