﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Provider { get; set; }
        public string TokenString { get; set; }
        public bool EmailConfirmed { get; set; } = false;
    }
}
