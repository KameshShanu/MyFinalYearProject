using DBStorage.Trips;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public class PackageListService : IPackageListService
    {
        private IPackageListRepository _packageListRepository;

        public PackageListService(PackageListRepository packageListRepository)
        {
            _packageListRepository = packageListRepository;
        }

        public PackagesList DeletePackageById(int packageId)
        {
            return _packageListRepository.DeletePackageById(packageId);
        }

        public IEnumerable<PackagesList> GetAllPackages()
        {
            return _packageListRepository.GetAllPackages();
        }

        public bool IsPackageExists(int id, string preDefineTripName)
        {
            return _packageListRepository.IsPackageExists(id, preDefineTripName);
        }

        public void SavePackage(PackagesList package)
        {
            _packageListRepository.SavePackage(package);
        }
    }
}
