using Domin.Common;
using System.Collections.Generic;

namespace Domain.Driver
{
    public interface IDriverRepository : IRepository<Driver>
    {
        IEnumerable<Driver> GetAllDrives();               
        void DeleteMultipleDrivers(IEnumerable<int> driversToDelete);
        bool IsDriverExists(string empNumber, string nIC);
        void SaveDriver(Driver driver);       
        void UpdateDriverAvailable(IEnumerable<int> driversToUpdate);
        void UpdateDriverUnAvailable(IEnumerable<int> driversToUpdate);
        IEnumerable<Driver> RetrieveTripsWithDriver();
    }
}
