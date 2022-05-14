using RealEstate.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IPublicationFiltersService
    {
        Task<IEnumerable<DistancesFromLocationRangeViewModel>> GetDistancesFromLocationRange();

        Task<IEnumerable<PublicationPublishedRangeViewModel>> GetPublicationPublishedRange();

        Task<IEnumerable<QuadraturesRangeViewModel>> GetQuadraturesRange();

        Task<IEnumerable<SortOrderViewModel>> GetSortOrder();
    }
}
