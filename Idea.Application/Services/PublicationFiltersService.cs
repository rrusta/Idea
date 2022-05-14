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
    public class PublicationFiltersService : IPublicationFiltersService
    {
        private readonly IMapper _mapper;
        private readonly IPublicationFiltersRepository _publicationFiltersRepository; 

        public PublicationFiltersService(IMapper mapper, IPublicationFiltersRepository publicationFiltersRepository)
        {
            _publicationFiltersRepository = publicationFiltersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DistancesFromLocationRangeViewModel>> GetDistancesFromLocationRange()
        {
            var distancesFromLocationRange = await _publicationFiltersRepository.GetAllAsync<DistancesFromLocationRange>();
            return _mapper.Map<IEnumerable<DistancesFromLocationRangeViewModel>>(distancesFromLocationRange);
        }

        public async Task<IEnumerable<PublicationPublishedRangeViewModel>> GetPublicationPublishedRange()
        {
            var publicationPublishedRange = await _publicationFiltersRepository.GetAllAsync<PublicationPublishedRange>();
            return _mapper.Map<IEnumerable<PublicationPublishedRangeViewModel>>(publicationPublishedRange);  
        }

        public async Task<IEnumerable<QuadraturesRangeViewModel>> GetQuadraturesRange()
        {
            var quadraturesRange = await _publicationFiltersRepository.GetAllAsync<QuadraturesRange>();
            return _mapper.Map<IEnumerable<QuadraturesRangeViewModel>>(quadraturesRange);
        }
        public async Task<IEnumerable<SortOrderViewModel>> GetSortOrder()
        {
            var sortOrder = await _publicationFiltersRepository.GetAllAsync<SortOrder>();
            return _mapper.Map<IEnumerable<SortOrderViewModel>>(sortOrder);
        }

    }
}
