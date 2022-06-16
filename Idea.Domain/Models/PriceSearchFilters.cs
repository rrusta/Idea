using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PriceSearchFilters
    {
        [Key]
        public int PriceSearchFilterId { get; set; }

        public int Value { get; set; }

        public string Text { get; set; }
    }
}
