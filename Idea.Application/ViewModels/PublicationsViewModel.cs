using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class PublicationsViewModel
    {
        public int? PublicationId { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        [Required]
        public int PublisherTypeId { get; set; }

        [Required]
        public int PublicationTypeId { get; set; }

        [Required]
        public int PublicationCategoryId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string WhatsappPhoneNumber { get; set; }

        public string ViberPhoneNumber { get; set; }

        public string PhonePrefix { get; set; }

        public string WhatsappPrefix { get; set; }

        public string ViberPrefix { get; set; }

        public decimal? Quadrature { get; set; }

        public int? QuadratureUnitId { get; set; }

        public decimal? Area { get; set; }

        public int? AreaUnitId { get; set; }

        public decimal? Price { get; set; } 

        public int? PriceUnitId { get; set; }

        public decimal? OriginalPrice { get; set; }

        [Required]
        public int DistrictId { get; set; }

        public int? TownId { get; set; }

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

        public bool? HasBalcony { get; set; }

        public bool? HasTerrace { get; set; }

        public bool? HasElectricCentralHeating { get; set; }

        public bool? HasRollerShutters { get; set; }

        public string Description { get; set; }

        public int? PublicationStatusId { get; set; }

        public string SelectedAttachment { get; set; }

        public List<string> DeletedAttachments { get; set; }

        public int? ParentPublicationId { get; set; }

        public int? PublicationStateId { get; set; }

        public string Avatar { get; set; }

        public bool? ByAgreement { get; set; }
        public bool? IsDeleted { get; set; } 
    }
}
