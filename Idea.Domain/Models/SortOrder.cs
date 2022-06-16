using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class SortOrder
    {
        [Key]
        public int SortOrderId { get; set; }

        public string Value { get; set; }

        public string Text { get; set; }
    }
}
