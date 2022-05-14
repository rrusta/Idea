using Microsoft.AspNetCore.Http;
using Idea.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.DTOViewModels.SelectDTOViewModels
{
    public class PublicationsSelectViewModel
    {
        public int? PublicationId { get; set; }

        public int? ParentPublicationId { get; set; }

        public string Email { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedByUser { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public int PublisherTypeId { get; set; }

        public string PublisherType { get; set; }

        public int PublicationTypeId { get; set; }

        public string PublicationType { get; set; }

        public int PublicationCategoryId { get; set; }

        public string PublicationCategory { get; set; }

        public string PhoneNumber { get; set; }

        public string WhatsappPhoneNumber { get; set; }

        public string ViberPhoneNumber { get; set; }

        public string PhonePrefix { get; set; }

        public string WhatsappPrefix { get; set; }

        public string ViberPrefix { get; set; }

        public decimal? Quadrature { get; set; }

        public int? QuadratureUnitId { get; set; }

        public string QuadratureUnit { get; set; }

        public decimal? Area { get; set; }

        public int? AreaUnitId { get; set; }

        public string AreaUnit { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal Price { get; set; }

        public int PriceUnitId { get; set; }

        public string PriceUnit { get; set; }

        public int DistrictId { get; set; }

        public string District { get; set; }

        public int? TownId { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string AddressObject { get; set; }

        public string AddressEntry { get; set; }

        public decimal? AddressLatitude { get; set; }

        public decimal? AddressLongitude { get; set; }

        public int? KitchenRoomNumber { get; set; }  

        public int? RoomsNumber { get; set; }

        public int? KitchenNumber { get; set; }

        public int? BedroomsNumber { get; set; }

        public int? WarehouseroomsNumber { get; set; }

        public int? BathroomsNumber { get; set; }

        public bool? HasElevator { get; set; }

        public bool? HasAirConditioner { get; set; }

        public bool? HasCentralHeating { get; set; }

        public bool? HasTV { get; set; }

        public bool? HasInternet { get; set; }

        public bool? HasClothesWasher { get; set; }

        public bool? HasDishWasher { get; set; }

        public bool? HasPrivateGarage { get; set; }

        public bool? HasPublicParking { get; set; }

        public bool? HasAlarm { get; set; }

        public bool? HasSwimmingPool { get; set; }

        public string Description { get; set; }

        public int? PublicationStatusId { get; set; }

        public string PublicationStatus { get; set; }

        public bool? IsFavorite { get; set; }

        public bool? Watched { get; set; }

        public bool? HasBalcony { get; set; }

        public bool? HasTerrace { get; set; }

        public bool? HasElectricCentralHeating { get; set; }

        public bool? HasRollerShutters { get; set; }

        public int? PublicationStateId { get; set; }

        public string PublicationState { get; set; }

        public string Avatar { get; set; }    

        public List<AttachmentsSelectViewModel> Attachments { get; set; }
        public List<RejectionReasonsViewModel> RejectionReasons { get; set; }

        public bool? ByAgreement { get; set; } 
        public bool? IsDeleted { get; set; }  

    }
}
