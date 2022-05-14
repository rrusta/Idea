using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.DTOViewModels.FilterDTOViewModels
{
    public class PublicationsSelectFilterViewModel
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 9;

        public string OrderBy { get; set; }

        public string Search { get; set; }

        public int? PublicationTypeId { get; set; }

        public int? PublicationCategoryId { get; set; }

        public string PublicationCategories { get; set; }

        public int? TownId { get; set; }

        public int? DistrictId { get; set; }

        public int? PublicationStateId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal? MyLatitude { get; set; }

        public decimal? MyLongitude { get; set; }

        public int? DistancesFromLocationRange { get; set; }

        public int? PublicationPublishedRange { get; set; }

        public int? QuadraturesRange { get; set; }

        public int? RoomsNumber { get; set; }

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
    }
}
