using AutoMapper;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly IMapper _mapper;
        private readonly IDistrictsRepository _districtsRepository;

        public DistrictsService(IMapper mapper, IDistrictsRepository districtsRepository)
        {
            _mapper = mapper;
            _districtsRepository = districtsRepository;
        }
        public async Task<IEnumerable<DistrictsViewModel>> GetDistricts()
        {
            return _mapper.Map<IEnumerable<DistrictsViewModel>>(await _districtsRepository.GetDistricts());
        }

        public async Task<IEnumerable<DistrictsViewModel>> GetDistrictsWithTowns()
        {
            return _mapper.Map<IEnumerable<DistrictsViewModel>>(await _districtsRepository.GetDistricstWithTowns()); 
        }
    }
}
