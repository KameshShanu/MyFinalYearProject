using DBStorage.Common;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class PackageListRepository : Repository<PackagesList>, IPackageListRepository
    {
        public PackageListRepository(WingsContext context) : base(context)
        {
        }

        public PackagesList DeletePackageById(int packageId)
        {
            PackagesList packageToDelete = Retrieve(pl => pl.PackageId.Equals(packageId)).Single();
            Delete(packageToDelete);
            return packageToDelete;
        }

        public IEnumerable<PackagesList> GetAllPackages()
        {
            return Context.Set<PackagesList>();
        }

        public bool IsPackageExists(int id, string preDefineTripName)
        {
            return !Context.PackagesList.Any(x => x.TripId == id && x.PreDefineTripName == preDefineTripName);
        }

        public void SavePackage(PackagesList package)
        {
            Save(package);
        }
    }
}
