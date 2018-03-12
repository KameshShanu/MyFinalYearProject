using Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Advertisements
{
    public interface IAdvertisementItemService
    {
        void SaveAdvertisementItem(AdvertisementItem advertisementItem);
        AdvertisementItem GetAdvertisementItemById(int id);
        void UpdateAdvertisementItem(AdvertisementItem advertisement);
        void DeleteAdvertisementItem(int id);
        void SortAdvertisementItems(List<int> items);
    }
}
