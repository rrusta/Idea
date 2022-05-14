using AutoMapper;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.Models;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class TownsService : ITownsService
    {
        private readonly IMapper _mapper;
        private readonly ITownsRepository _townsRepository;

        public TownsService(IMapper mapper, ITownsRepository townsRepository)
        {
            _mapper = mapper;
            _townsRepository = townsRepository;
        }
        public async Task<IEnumerable<TownsViewModel>> GetTowns()
        {
            return _mapper.Map<IEnumerable<TownsViewModel>>(await _townsRepository.GetTowns());
        }
        public async Task<IEnumerable<TownsViewModel>> GetTownsByDistrict(int districtId)
        {
            return _mapper.Map<IEnumerable<TownsViewModel>>(await _townsRepository.GetTownsByDistrict(districtId));
        }
    }
}
