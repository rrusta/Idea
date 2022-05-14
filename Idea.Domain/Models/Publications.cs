using Idea.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class Publications : BaseModel
    {
        public int PublicationId { get; set; }

        public int PublisherTypeId { get; set; }
        public PublisherTypes PublisherType { get; set; }

        public int PublicationTypeId { get; set; }
        public PublicationTypes PublicationType { get; set; }

        public int PublicationCategoryId { get; set; }
        public PublicationCategories PublicationCategory { get; set; }

        public string PhoneNumber { get; set; }

        public string WhatsappPhoneNumber { get; set; }

        public string ViberPhoneNumber { get; set; }

        public string PhonePrefix { get; set; }

        public string WhatsappPrefix { get; set; }

        public string ViberPrefix { get; set; }

        public decimal? Quadrature { get; set; }
        public int? QuadratureUnitId { get; set; }
        public Units QuadratureUnit { get; set; }

        public decimal? Area { get; set; }
        public int? AreaUnitId { get; set; }
        public Units AreaUnit { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal? Price { get; set; }
        public int? PriceUnitId { get; set; }
        public Units PriceUnit { get; set; }

        public int DistrictId { get; set; }
        public Districts District { get; set; }

        public int? TownId { get; set; }
        public Towns Town { get; set; }

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

        public int PublicationStatusId { get; set; }
        public PublicationStatuses PublicationStatus { get; set; }

        public int? ParentPublicationId { get; set; }
        public Publications ParentPublication { get; set; }
        public int? PublicationStateId { get; set; }
        public PublicationStates PublicationState { get; set; }
        public bool? ByAgreement { get; set; }
        public bool? IsDeleted { get; set; } 
    }
}
