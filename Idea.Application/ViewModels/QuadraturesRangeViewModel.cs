﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class QuadraturesRangeViewModel
    {
        public int QuadratureRangeId { get; set; }

        public string Description { get; set; }

        public int? QuadratureFrom { get; set; }

        public int? QuadratureTo { get; set; }

        public int? UnitId { get; set; }
    }
}
