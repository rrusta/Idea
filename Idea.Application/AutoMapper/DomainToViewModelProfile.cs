using AutoMapper;
using Idea.Application.DTOViewModels.FilterDTOViewModels;
using Idea.Application.DTOViewModels.InsertDTOViewModels;
using Idea.Application.DTOViewModels.SelectDTOViewModels;
using Idea.Application.DTOViewModels.UpdateDTOViewModels;
using Idea.Application.ViewModels;
using Idea.Domain.DTOs.InsertDTOs;
using Idea.Domain.DTOs.UpdateDTOs;
using Idea.Domain.IdentityModels;
using Idea.Domain.Models;
using RealEstate.Domain.DTOs.FilterDTOs;
using RealEstate.Domain.DTOs.SelectDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<AttachmentsSelect, AttachmentsSelectViewModel>();
            CreateMap<AttachmentsSelectViewModel, AttachmentsSelect>();

            CreateMap<UserViewModel, ApplicationUser>();
            CreateMap<ApplicationUser, UserViewModel>();

            CreateMap<Districts, DistrictsViewModel>();
            CreateMap<Towns, TownsViewModel>();
            CreateMap<PublicationCategories, PublicationCategoriesViewModel>();
            CreateMap<PublicationMainCategories, PublicationMainCategoriesViewModel>();
            CreateMap<PublicationTypes, PublicationTypesViewModel>();
            CreateMap<PublisherTypes, PublisherTypesViewModel>();
            CreateMap<Units, UnitsViewModel>();
            CreateMap<UserTypes, UserTypesViewModel>();
            CreateMap<UnitTypes, UnitTypesViewModel>();
            CreateMap<PublicationsSelect, PublicationsSelectViewModel>();
            CreateMap<PublicationsSelectFilterViewModel, PublicationsSelectFilter>();
            CreateMap<ApplicationUser, LoggedProfileViewModel>();
            CreateMap<DistancesFromLocationRange, DistancesFromLocationRangeViewModel>();
            CreateMap<PublicationPublishedRange, PublicationPublishedRangeViewModel>();
            CreateMap<QuadraturesRange, QuadraturesRangeViewModel>();
            CreateMap<UpdateProfilePictureViewModel, UpdateProfilePicture>();
            CreateMap<FavoritePublicationsViewModel, FavoritePublications>();
            CreateMap<WatchedPublicationsViewModel, WatchedPublications>();
            CreateMap<PublicationCategoriesProperties, PublicationCategoriesPropertiesViewModel>();

            CreateMap<Publications, PublicationsViewModel>();
            CreateMap<PublicationsViewModel, Publications>();
            CreateMap<SortOrder, SortOrderViewModel>();
            CreateMap<PhonePrefixes, PhonePrefixesViewModel>();
            CreateMap<UserMessageEmailViewModel, UserMessageEmail>();
            CreateMap<Publications, PublicationsSelectViewModel>();
            CreateMap<RejectionReasons, RejectionReasonsViewModel>();
            CreateMap<PublicationStates, PublicationStatesViewModel>();
            CreateMap<PriceSearchFilters, PublicationPricesViewModel>();
            CreateMap<RoomsNumberSearchFilters, PublicationRoomsViewModel>();
        }
    }
}
