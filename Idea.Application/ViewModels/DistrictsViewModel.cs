using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class DistrictsViewModel
    {
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public string DistrictCode { get; set; }

        public List<TownsViewModel> Towns { get; set; }
    }
}
