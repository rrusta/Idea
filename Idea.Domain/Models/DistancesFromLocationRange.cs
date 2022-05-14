using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class DistancesFromLocationRange
    {
        public int DistanceFromLocationRangeId { get; set; }

        public string Description { get; set; }

        public int? DistanceFrom { get; set; }

        public int? DistanceTo { get; set; }

        public int? UnitId { get; set; }
        public Units Unit { get; set; }
    }
}
