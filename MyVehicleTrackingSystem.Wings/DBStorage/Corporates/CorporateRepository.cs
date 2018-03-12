using DBStorage.Common;
using Domain.Corporates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Corporates
{
    public class CorporateRepository : Repository<Corporate>, ICorporateRepository
    {
        public CorporateRepository(WingsContext context) : base(context)
        {

        }

        public void DeleteMultipleCorporates(IEnumerable<int> corporatesToDelete)
        {
            Context.Corporate.Where(v => corporatesToDelete.Contains(v.CorporateId)).ToList().ForEach(v => v.IsDeleted = true);
            Context.Commit();
        }

        public IEnumerable<Corporate> RetrieveCorporate()
        {
            return Context.Set<Corporate>().Where(a => a.IsDeleted == false);
        }

        public Corporate RetrieveCorporateById(int id)
        {
            return RetrieveByKey(id);
        }

        public void SaveCorporate(Corporate model)
        {
            Save(model);
        }

        public void UpdateCorporate(Corporate model)
        {
            Corporate corporate = RetrieveByKey(model.CorporateId);
            corporate.CorporateName = model.CorporateName;
            corporate.CorporateDetails = model.CorporateDetails;
            Save(corporate);
        }
    }
}
