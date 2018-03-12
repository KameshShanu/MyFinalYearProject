using System.Collections.Generic;
using Domain.Driver;

namespace Application.Driver
{
    public interface IDriverService
    {
        Domain.Driver.Driver GetDriverById(int id);
        Domain.Driver.Driver GetUserByNic(string nic);
        IEnumerable<Domain.Driver.Driver> GetAllDrivers();
        void SaveDriver(Domain.Driver.Driver driver);
        void DeleteDriver(int id);
        void DeleteMultipleTrips(IEnumerable<int> tripsToDelete);
        bool IsDriverExists(string epfNumber, string nIC);
        void UpdateDriverAvailable(IEnumerable<int> driversToUpdate);
        void UpdateDriverUnAvailable(IEnumerable<int> driversToUpdate);
        IEnumerable<Domain.Driver.Driver> RetrieveTripsWithDriver();
    }
}
