using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class TownsViewModel
    {
        public int TownId { get; set; }
        public string Name { get; set; }
        public string TownCode { get; set; }
        public int DistrictId { get; set; }

    }
}