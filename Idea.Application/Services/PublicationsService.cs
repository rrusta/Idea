using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOViewModels.FilterDTOViewModels;
using RealEstate.Application.DTOViewModels.InsertDTOViewModels;
using RealEstate.Application.DTOViewModels.SelectDTOViewModels;
using RealEstate.Application.Enums;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.DTOs.FilterDTOs;
using RealEstate.Domain.DTOs.SelectDTOs;
using RealEstate.Domain.Models;
using RealEstate.Infrastructure.Data.Interfaces;
using RealEstate.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.IdentityModels;
using System.Security.Claims;

namespace RealEstate.Application.Services
{
    public class PublicationsService : IPublicationsService
    {
        private readonly IMapper _mapper;
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationsService(IMapper mapper, IPublicationsRepository publicationsRepository)  
        {
            _mapper = mapper;
            _publicationsRepository = publicationsRepository;
        }

        public async Task<IEnumerable<PublicationCategoriesViewModel>> GetPublicationCategories()
        {
            var publicationCategories = await _publicationsRepository.GetAllAsync<PublicationCategories>();
            return _mapper.Map<IEnumerable<PublicationCategoriesViewModel>>(publicationCategories);
        }

        public async Task<IEnumerable<PublicationMainCategoriesViewModel>> GetPublicationMainCategories()
        {
            var publicationMainCategories = await _publicationsRepository.GetAllAsync<PublicationMainCategories>();
            return _mapper.Map<IEnumerable<PublicationMainCategoriesViewModel>>(publicationMainCategories);
        }

        public async Task<IEnumerable<PublicationTypesViewModel>> GetPublicationTypes()
        {
            var publicationTypes = await _publicationsRepository.GetAllAsync<PublicationTypes>();
            return _mapper.Map<IEnumerable<PublicationTypesViewModel>>(publicationTypes);
        }
        public async Task<IEnumerable<PublisherTypesViewModel>> GetPublisherTypes()
        {
            var publisherTypes = await _publicationsRepository.GetAllAsync<PublisherTypes>();
            return _mapper.Map<IEnumerable<PublisherTypesViewModel>>(publisherTypes);
        }

        public async Task<PublicationsViewModel> PublicationInsert(PublicationsViewModel publicationViewModel, IFormFileCollection attachments)
        {
            var publication = _mapper.Map<Publications>(publicationViewModel);
            publication.CreatedAt = DateTime.Now;
            publication.LastUpdatedAt = DateTime.Now;
            publication.PublicationStatusId = (int)PublicationStatusesEnum.NeShqyrtim;
            publication.PublicationStateId = 1;
            var result = await _publicationsRepository.InsertAsync(publication);
            await _publicationsRepository.InsertAttachmentsWithFiles(attachments, result.PublicationId, publicationViewModel.SelectedAttachment);
            //await _emailTemplatesRepository.SendPublicationAddedEmail(result.PublicationId);
            return _mapper.Map<PublicationsViewModel>(result);
        }

        public async Task<PublicationsViewModel> PublicationUpdate(PublicationsViewModel publicationViewModel, List<AttachmentsSelectViewModel> attachmentsViewModel, IFormFileCollection files)
        {
            var publication = _mapper.Map<Publications>(publicationViewModel);
            var attachments = _mapper.Map<List<AttachmentsSelect>>(attachmentsViewModel);
            publication.LastUpdatedAt = DateTime.Now;
            var result = new Publications();

            if (publicationViewModel.PublicationStatusId == (int)PublicationStatusesEnum.Postuar)
            {
                publication.CreatedAt = DateTime.Now;
                publication.PublicationStatusId = (int)PublicationStatusesEnum.NeShqyrtimNdryshimet;
                publication.ParentPublicationId = publication.PublicationId;
                publication.PublicationId = 0;
                result = await _publicationsRepository.InsertAsync(publication);
            }
            else
            {
                if (publicationViewModel.PublicationStatusId == (int)PublicationStatusesEnum.Refuzuar)
                    publication.PublicationStatusId = (int)PublicationStatusesEnum.NeShqyrtimNdryshimet;

                result = await _publicationsRepository.UpdateAsync(publication, publication.PublicationId);
                await _publicationsRepository.DeleteAttachmentsMetaData(publication.PublicationId);
            }

            await _publicationsRepository.InsertAttachments(attachments, result.PublicationId, publicationViewModel.SelectedAttachment);
            await _publicationsRepository.InsertAttachmentsWithFiles(files, result.PublicationId, publicationViewModel.SelectedAttachment);
            //await _emailTemplatesRepository.SendPublicationEditedEmail(result.PublicationId);

            return _mapper.Map<PublicationsViewModel>(result);
        }

        public async Task<PublicationsSelectViewModel> ApprovePublication(ApprovePublicationViewModel approvePublicationViewModel)
        {
            var result = new Publications();
            
            if (approvePublicationViewModel.PublicationStatusId == (int)PublicationStatusesEnum.Postuar)
            {
                result = await _publicationsRepository.ApprovePublication(approvePublicationViewModel.PublicationId);
                //var publisher = await _userManager.FindByIdAsync(result.CreatedBy);
                //await _emailTemplatesRepository.SendApprovePublicationEmail(publisher.Email);
            }
            else
            {
                result = await _publicationsRepository.RejectPublication(approvePublicationViewModel.PublicationId, approvePublicationViewModel.RejectReasons);
                //var publisher = await _userManager.FindByIdAsync(result.CreatedBy);
                //await _emailTemplatesRepository.SendRejectPublicationEmail(publisher.Email, result.PublicationId); 
            }

            var publication = _mapper.Map<PublicationsSelectViewModel>(result);

            return publication;
        }

        public async Task<IEnumerable<UnitsViewModel>> GetUnitsByType(int unitTypeId)
        {
            return _mapper.Map<IEnumerable<UnitsViewModel>>(await _publicationsRepository.GetUnitsByType(unitTypeId));
        }
        public async Task<IEnumerable<PhonePrefixesViewModel>> GetPhonePrefixes()
        {
            var phonePrefixes = await _publicationsRepository.GetAllAsync<PhonePrefixes>();
            return _mapper.Map<IEnumerable<PhonePrefixesViewModel>>(phonePrefixes);
        }

        public async Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetAllPublications(PublicationsSelectFilterViewModel filterViewModel, string userId)
        {
            var filter = _mapper.Map<PublicationsSelectFilter>(filterViewModel);
            var result = await _publicationsRepository.GetAllPublications(filter, userId);
            var publications = _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result.Publications);
            return (publications, result.RecordCount);
        }

        public async Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetFavoritePublications(PublicationsSelectFilterViewModel filterViewModel, string userId)
        {
            var filter = _mapper.Map<PublicationsSelectFilter>(filterViewModel);
            var result = await _publicationsRepository.GetFavoritePublications(filter,userId);
            var publications = _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result.Publications);
            return (publications, result.RecordCount);
        }

        public async Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetWatchedPublications(PublicationsSelectFilterViewModel filterViewModel, string userId)
        {
            var filter = _mapper.Map<PublicationsSelectFilter>(filterViewModel);
            var result = await _publicationsRepository.GetWatchedPublications(filter,userId);
            var publications = _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result.Publications);
            return (publications, result.RecordCount);
        }
        public async Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetAwaitingPublications(PublicationsSelectFilterViewModel filterViewModel, string userId)
        {
            var filter = _mapper.Map<PublicationsSelectFilter>(filterViewModel);
            var result = await _publicationsRepository.GetAwaitingPublications(filter, userId);
            var publications = _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result.Publications);
            return (publications, result.RecordCount);
        }

        public async Task<(IEnumerable<PublicationsSelectViewModel> Publications, int RecordCount)> GetMyPublications(PublicationsSelectFilterViewModel filterViewModel, string userId)
        {
            var filter = _mapper.Map<PublicationsSelectFilter>(filterViewModel);
            var result = await _publicationsRepository.GetMyPublications(filter,userId);
            var publications = _mapper.Map<IEnumerable<PublicationsSelectViewModel>>(result.Publications);
            return (publications, result.RecordCount);
        }

        public async Task<bool> FavoritePublication(FavoritePublicationsViewModel addFavoritePublicationViewModel)
        {
            var favoritePublication = _mapper.Map<FavoritePublications>(addFavoritePublicationViewModel);
            return await _publicationsRepository.FavoritePublications(favoritePublication);

        }

        public async Task<bool> WatchedPublications(WatchedPublicationsViewModel watchedPublicationViewModel)
        {
            var watchedPublications = _mapper.Map<WatchedPublications>(watchedPublicationViewModel);
            return await _publicationsRepository.WatchedPublications(watchedPublications);
        }

        public async Task<PublicationsSelectViewModel> GetPublicationDetails(int publicationId, string userId)
        {
            var result = await _publicationsRepository.GetPublicationDetails(publicationId, userId);

            //var loggedUser = await _userManager.FindByIdAsync(userId);
            //var userPrincipal = await _signInManager.CreateUserPrincipalAsync(loggedUser);
            //var isLoggedIn = _signInManager.IsSignedIn(userPrincipal);

            if (!string.IsNullOrEmpty(userId))
            {
                WatchedPublicationsViewModel watchedPublication = new WatchedPublicationsViewModel() 
                {
                    UserId = userId,
                    PublicationId = result.PublicationId,
                };

                await WatchedPublications(watchedPublication);
            }

            return _mapper.Map<PublicationsSelectViewModel>(result);
        }

        public async Task<PublicationsSelectViewModel> GetPublication(int publicationId, string userId)
        {
            var result = await _publicationsRepository.GetPublication(publicationId, userId);
            return _mapper.Map<PublicationsSelectViewModel>(result);
        }

        public async Task<bool> ChangePublicationState(int publicationId, int publicationStateId)
        {
            return await _publicationsRepository.ChangePublicationState(publicationId, publicationStateId);
        }

        public async Task<bool> RefreshPublication(int publicationId)
        {
            return await _publicationsRepository.RefreshPublication(publicationId);
        }

        public async Task<bool> DeletePublicationByIsDeleted(int publicationId) 
        {
            return await _publicationsRepository.DeletePublicationByIsDeleted(publicationId);
        }
    }
}
