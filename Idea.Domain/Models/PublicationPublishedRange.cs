using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationPublishedRange
    {
        [Key]
        public int PublicationPublishedRangeId { get; set; }

        public string Description { get; set; }

        public int? PublishedFrom { get; set; }

        public int? PublishedTo { get; set; }

        public int? UnitId { get; set; }
        public Units Unit { get; set; }
    }
}
