using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class OperatorSettings
    {
        public int OperatorSettingsId { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Smtp { get; set; }

        public int Port { get; set; }
    }
}
