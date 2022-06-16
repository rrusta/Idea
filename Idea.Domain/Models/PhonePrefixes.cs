using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PhonePrefixes
    {
        [Key]
        public int PhonePrefixId { get; set; }

        public string Value { get; set; }

        public string Text { get; set; }

        public string CountryCode { get; set; }

        public bool IsImportant { get; set; }
    }
}
