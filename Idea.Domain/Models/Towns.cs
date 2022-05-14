using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class Towns
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public string TownCode { get; set; }

        public int DistrictId { get; set; }

        public Districts District { get; set; }
    }
}
