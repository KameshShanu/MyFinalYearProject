using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Advertisements;
using DBStorage.Advertisements;

namespace Application.Advertisements
{
    public class AdvertisementCategoryService : IAdvertisementCategoryService
    {
        private IAdvertisementCategoryRepository _resitory;

        public AdvertisementCategoryService(AdvertisementCategoryRepository repository)
        {
            _resitory = repository;
        }

        public void DeleteAdvertisementCategory(int id)
        {
            _resitory.DeleteAdvertisementCategory(id);
        }

        public AdvertisementCategory GetAdvertisementCategoryById(int id)
        {
            return _resitory.GetAdvertisementCategoryById(id);
        }

        public IEnumerable<AdvertisementCategory> getAdvertisements()
        {
            return _resitory.getAdvertisements();
        }

        public void SaveAdvertisementCategory(AdvertisementCategory advertisementCategory)
        {
            _resitory.SaveAdvertisementCategory(advertisementCategory);
        }

        public void SortAdvertisementCategories(List<int> items)
        {
            _resitory.SortAdvertisementCategories(items);
        }

        public void UpdateAdvertisementCategory(AdvertisementCategory advertisement)
        {
            _resitory.UpdateAdvertisementCategory(advertisement);
        }
    }
}
