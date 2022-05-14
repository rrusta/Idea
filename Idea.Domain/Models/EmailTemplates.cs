using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class EmailTemplates
    {
        public int EmailTemplateId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }
    }
}
