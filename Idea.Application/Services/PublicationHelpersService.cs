using AutoMapper;
using RealEstate.Application.DTOViewModels.SelectDTOViewModels;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class PublicationHelpersService : IPublicationHelpersService
    {
        private readonly IMapper _mapper;
        private readonly IPublicationHelpersRepository _publicationHelpersRepository;

        public PublicationHelpersService(IMapper mapper, IPublicationHelpersRepository publicationHelpersRepository)
        {
            _mapper = mapper;
            _publicationHelpersRepository = publicationHelpersRepository;
        }

        public async Task<IEnumerable<RejectionReasonsViewModel>> GetRejectionReasons()
        {
            var result = await _publicationHelpersRepository.GetRejectionReasons();
            return _mapper.Map<IEnumerable<RejectionReasonsViewModel>>(result);
        }

        public async Task<IEnumerable<PublicationsSelectViewModel>> GetSimilarPublications(int publicationId, string userId)
        {
            var result = await _publicationHelpersRepository.GetSimilarPublications(publicationId, userId);
            return _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result);
        }

        public async Task<IEnumerable<PublicationStatesViewModel>> GetPublicationStates() 
        {
            var result = await _publicationHelpersRepository.GetPublicationStates(); 
            return _mapper.Map<IEnumerable<PublicationStatesViewModel>>(result); 
        }
        public async Task<IEnumerable<PublicationCategoriesPropertiesViewModel>> GetPublicationCategoriesProperties()
        {
            var result = await _publicationHelpersRepository.GetPublicationCategoriesProperties();
            return _mapper.Map<IEnumerable<PublicationCategoriesPropertiesViewModel>>(result);
        }
        public async Task<IEnumerable<PublicationPricesViewModel>> GetPublicationPrices()
        {
            var result = await _publicationHelpersRepository.GetPublicationPrices();
            return _mapper.Map<IEnumerable<PublicationPricesViewModel>>(result);
        }
        public async Task<IEnumerable<PublicationRoomsViewModel>> GetPublicationRooms()
        {
            var result = await _publicationHelpersRepository.GetPublicationRooms();
            return _mapper.Map<IEnumerable<PublicationRoomsViewModel>>(result);
        }
    }
}
