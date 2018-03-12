using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Advertisements;
using DBStorage.Advertisements;

namespace Application.Advertisements
{
    public class AdvertisementItemService : IAdvertisementItemService
    {
        private IAdvertisementItemRepository _resitory;

        public AdvertisementItemService(AdvertisementItemRepository repository)
        {
            _resitory = repository;
        }

        public void DeleteAdvertisementItem(int id)
        {
            _resitory.DeleteAdvertisementItem(id);
        }

        public AdvertisementItem GetAdvertisementItemById(int id)
        {
            return _resitory.GetAdvertisementItemById(id);
        }

        public void SaveAdvertisementItem(AdvertisementItem advertisementItem)
        {
            _resitory.SaveAdvertisementItem(advertisementItem);
        }

        public void SortAdvertisementItems(List<int> items)
        {
            _resitory.SortAdvertisementItems(items);
        }

        public void UpdateAdvertisementItem(AdvertisementItem advertisement)
        {
            _resitory.UpdateAdvertisementItem(advertisement);
        }
    }
}
