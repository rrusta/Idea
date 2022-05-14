using RealEstate.Application.DTOViewModels.SelectDTOViewModels;
using RealEstate.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IPublicationHelpersService
    {   
        Task<IEnumerable<RejectionReasonsViewModel>> GetRejectionReasons();
        Task<IEnumerable<PublicationsSelectViewModel>> GetSimilarPublications(int publicationId, string userId);
        Task<IEnumerable<PublicationStatesViewModel>> GetPublicationStates();
        Task<IEnumerable<PublicationCategoriesPropertiesViewModel>> GetPublicationCategoriesProperties();
        Task<IEnumerable<PublicationPricesViewModel>> GetPublicationPrices();
        Task<IEnumerable<PublicationRoomsViewModel>> GetPublicationRooms();
    }
}