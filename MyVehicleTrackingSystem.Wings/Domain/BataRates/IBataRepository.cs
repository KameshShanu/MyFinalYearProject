using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BataRates
{
    public interface IBataRepository : IRepository<BataRate>
    {
        IEnumerable<BataRate> GetAllBataRates();
        void DeleteMultipleBataRates(IEnumerable<int> bataRateToDelete);
        void SaveBataRates(BataRate model);
    }
}
