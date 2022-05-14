using Microsoft.AspNetCore.Http;
using RealEstate.Application.DTOViewModels.FilterDTOViewModels;
using RealEstate.Application.DTOViewModels.InsertDTOViewModels;
using RealEstate.Application.DTOViewModels.SelectDTOViewModels;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IPublicationsService
    {
        Task<IEnumerable<PublicationCategoriesViewModel>> GetPublicationCategories();
        Task<IEnumerable<PublicationMainCategoriesViewModel>> GetPublicationMainCategories();
        Task<IEnumerable<PublicationTypesViewModel>> GetPublicationTypes();
        Task<IEnumerable<PublisherTypesViewModel>> GetPublisherTypes();
        Task<IEnumerable<UnitsViewModel>> GetUnitsByType(int unitTypeId);
        Task<IEnumerable<PhonePrefixesViewModel>> GetPhonePrefixes();
        Task<PublicationsViewModel> PublicationInsert(PublicationsViewModel publicationViewModel, IFormFileCollection attachments);
        Task<PublicationsViewModel> PublicationUpdate(PublicationsViewModel publicationViewModel, List<AttachmentsSelectViewModel> attachmentsViewModel, IFormFileCollection files);
        Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetAllPublications(PublicationsSelectFilterViewModel filterViewModel, string userId);
        Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetFavoritePublications(PublicationsSelectFilterViewModel filterViewModel, string userId);
        Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetWatchedPublications(PublicationsSelectFilterViewModel filterViewModel, string userId);
        Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetMyPublications(PublicationsSelectFilterViewModel filterViewModel, string userId);
        Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetAwaitingPublications(PublicationsSelectFilterViewModel filterViewModel, string userId);
        Task<bool> FavoritePublication(FavoritePublicationsViewModel addFavoritePublicationViewModel);
        Task<bool> WatchedPublications(WatchedPublicationsViewModel watchedPublicationViewModel);  
        Task<PublicationsSelectViewModel> GetPublicationDetails(int publicationId, string userId);
        Task<PublicationsSelectViewModel> GetPublication(int publicationId, string userId);
        Task<bool> DeletePublicationByIsDeleted(int publicationId); 
        Task<PublicationsSelectViewModel> ApprovePublication(ApprovePublicationViewModel approvePublicationViewModel);
        Task<bool> ChangePublicationState(int publicationId, int publicationStateId); 
        Task<bool> RefreshPublication(int publicationId);  
    }
}
