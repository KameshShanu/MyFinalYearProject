using System;
using System.Collections.Generic;
using Domain.Driver;
using DBStorage.Driver;
using System.Linq;

namespace Application.Driver
{
    public class DriverService : IDriverService
    {
        private IDriverRepository _driverResitory;
        public DriverService(DriverRepository driverRepository)
        {
            _driverResitory = driverRepository;
        }

        public void DeleteDriver(int id)
        {
            Domain.Driver.Driver driver = GetDriverById(id);

            if (driver != null)
            {
                _driverResitory.Delete(driver);
                _driverResitory.Save(driver);
            }
        }

        public void DeleteMultipleTrips(IEnumerable<int> tripsToDelete)
        {
            _driverResitory.DeleteMultipleDrivers(tripsToDelete);
        }

        public IEnumerable<Domain.Driver.Driver> GetAllDrivers()
        {
            return _driverResitory.GetAllDrives();
        }

        public Domain.Driver.Driver GetDriverById(int id)
        {
            return _driverResitory.Retrieve(d => d.DriverId == id).FirstOrDefault();
        }

        public Domain.Driver.Driver GetUserByNic(string nic)
        {
            return _driverResitory.Retrieve(d => d.NIC == nic).FirstOrDefault();
        }

        public bool IsDriverExists(string epfNumber, string nIC)
        {
            return _driverResitory.IsDriverExists(epfNumber, nIC);
        }

        public IEnumerable<Domain.Driver.Driver> RetrieveTripsWithDriver()
        {
            return _driverResitory.RetrieveTripsWithDriver();
        }

        public void SaveDriver(Domain.Driver.Driver driver)
        {
            _driverResitory.SaveDriver(driver);
        }

        public void UpdateDriverAvailable(IEnumerable<int> driversToUpdate)
        {
            _driverResitory.UpdateDriverAvailable(driversToUpdate);
        }

        public void UpdateDriverUnAvailable(IEnumerable<int> driversToUpdate)
        {
            _driverResitory.UpdateDriverUnAvailable(driversToUpdate);
        }
    }
}
