using DBStorage.Common;
using Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Advertisements
{
    public class AdvertisementItemRepository : Repository<AdvertisementItem>, IAdvertisementItemRepository
    {
        public AdvertisementItemRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteAdvertisementItem(int id)
        {
            AdvertisementItem advertisement = RetrieveByKey(id);
            advertisement.IsDeleted = true;
            Save(advertisement);
        }

        public AdvertisementItem GetAdvertisementItemById(int id)
        {
            return RetrieveByKey(id);
        }

        public void SaveAdvertisementItem(AdvertisementItem advertisementItem)
        {
            Save(advertisementItem);
        }

        public void SortAdvertisementItems(List<int> items)
        {
            var order = 1;
            foreach (var item in items)
            {
                AdvertisementItem advertisement = RetrieveByKey(item);
                advertisement.OrderId = order;
                Save(advertisement);
                order++;
            }
        }

        public void UpdateAdvertisementItem(AdvertisementItem advertisement)
        {
            AdvertisementItem adver = RetrieveByKey(advertisement.ItemId);
            adver.ItemName = advertisement.ItemName;
            adver.FileURL = advertisement.FileURL;
            adver.IsModified = true;
            adver.ModifiedDate = advertisement.ModifiedDate;
            Save(adver);
        }
    }
}
