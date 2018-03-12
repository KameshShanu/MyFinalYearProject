using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public interface IPackageListRepository : IRepository<PackagesList>
    {
        IEnumerable<PackagesList> GetAllPackages();
        bool IsPackageExists(int id, string preDefineTripName);
        PackagesList DeletePackageById(int packageId);
        void SavePackage(PackagesList package);
    }
}
