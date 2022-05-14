using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class DistancesFromLocationRangeViewModel
    {
        public int DistanceFromLocationRangeId { get; set; }

        public string Description { get; set; }

        public int? DistanceFrom { get; set; }

        public int? DistanceTo { get; set; }

        public int? UnitId { get; set; }
    }
}
