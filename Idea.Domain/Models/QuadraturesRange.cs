using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class QuadraturesRange
    {
        [Key]
        public int QuadratureRangeId { get; set; }

        public string Description { get; set; }

        public int? QuadratureFrom { get; set; }

        public int? QuadratureTo { get; set; }

        public int? UnitId { get; set; }
        public Units Unit { get; set; }
    }
}
