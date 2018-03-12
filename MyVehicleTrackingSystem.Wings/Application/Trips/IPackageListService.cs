using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public interface IPackageListService
    {
        IEnumerable<Domain.Trips.PackagesList> GetAllPackages();
        void SavePackage(Domain.Trips.PackagesList package);
        PackagesList DeletePackageById(int packageId);
        bool IsPackageExists(int id, string preDefineTripName);
    }
}
