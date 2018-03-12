using DBStorage.Common;
using Domain.BataRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.BataRates
{
    public class BataRateRepository : Repository<BataRate>, IBataRepository
    {

        public BataRateRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultipleBataRates(IEnumerable<int> bataRateToDelete)
        {
            Context.BataRate.Where(p => bataRateToDelete.Contains(p.BataId)).ToList().ForEach(p => p.IsDeleted = true);
            Context.Commit();
        }

        public IEnumerable<BataRate> GetAllBataRates()
        {
            return Context.Set<BataRate>().Where(a => a.IsDeleted != true);
        }

        public void SaveBataRates(BataRate model)
        {
            Save(model);
        }
    }
}
