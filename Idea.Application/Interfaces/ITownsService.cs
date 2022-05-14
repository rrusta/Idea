using RealEstate.Application.ViewModels;
using RealEstate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface ITownsService
    {
        Task<IEnumerable<TownsViewModel>> GetTowns();
        Task<IEnumerable<TownsViewModel>> GetTownsByDistrict(int districtId);
        
    }
}
