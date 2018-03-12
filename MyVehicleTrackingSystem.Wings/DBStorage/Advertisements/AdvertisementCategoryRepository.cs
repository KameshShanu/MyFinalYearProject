using Dapper;
using DBStorage.Common;
using Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Advertisements
{
    public class AdvertisementCategoryRepository : Repository<AdvertisementCategory>, IAdvertisementCategoryRepository
    {
        public AdvertisementCategoryRepository(WingsContext context) : base(context)
        {
        }
        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection();
            WingsContext wings = WingsContext.GetInstance();
            connection.ConnectionString = wings.Database.Connection.ConnectionString;
            connection.Open();
            return connection;
        }
        public IEnumerable<AdvertisementCategory> getAdvertisements()
        {
            try
            {
                SPRetrieveAdvertisement parameters = new SPRetrieveAdvertisement();
                using (var connection = GetConnection())
                {
                    using (var resultSet = connection.QueryMultiple(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure))
                    {
                        var categoryList = resultSet.Read<AdvertisementCategory>().ToList();
                        var itemList = resultSet.Read<AdvertisementItem>().ToList();
                        categoryList = resultSet.MapChild
                            (
                                categoryList,
                                itemList,
                                c => c.CategoryId,
                                i => i.CategoryId,
                                (c, i) => { c.AdvertisementItem = i.ToList(); }
                            ).ToList();
                        return categoryList;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void SaveAdvertisementCategory(AdvertisementCategory advertisementCategory)
        {
            Save(advertisementCategory);
        }

        public AdvertisementCategory GetAdvertisementCategoryById(int id)
        {
            return RetrieveByKey(id);
        }

        public void UpdateAdvertisementCategory(AdvertisementCategory advertisement)
        {
            AdvertisementCategory adver = RetrieveByKey(advertisement.CategoryId);
            adver.CategoryName = advertisement.CategoryName;
            adver.FileURL = advertisement.FileURL;
            adver.IsModified = true;
            adver.ModifiedDate = advertisement.ModifiedDate;
            Save(adver);
        }

        public void DeleteAdvertisementCategory(int id)
        {
            AdvertisementCategory advertisement = RetrieveByKey(id);
            advertisement.IsDeleted = true;
            Save(advertisement);
        }

        public void SortAdvertisementCategories(List<int> items)
        {
            var order = 1;
            foreach (var item in items)
            {
                AdvertisementCategory advertisement = RetrieveByKey(item);
                advertisement.OrderId = order;
                Save(advertisement);
                order++;
            }
        }
    }
}
