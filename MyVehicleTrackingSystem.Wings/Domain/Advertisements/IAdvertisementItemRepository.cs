using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Advertisements
{
    public interface IAdvertisementItemRepository
    {
        void SaveAdvertisementItem(AdvertisementItem advertisementItem);
        AdvertisementItem GetAdvertisementItemById(int id);
        void UpdateAdvertisementItem(AdvertisementItem advertisement);
        void DeleteAdvertisementItem(int id);
        void SortAdvertisementItems(List<int> items);
    }
}
