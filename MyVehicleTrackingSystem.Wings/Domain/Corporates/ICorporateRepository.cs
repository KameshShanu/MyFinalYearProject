using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Corporates
{
    public interface ICorporateRepository : IRepository<Corporate>
    {
        IEnumerable<Corporate> RetrieveCorporate();
        void SaveCorporate(Corporate model);
        Corporate RetrieveCorporateById(int id);
        void UpdateCorporate(Corporate model);
        void DeleteMultipleCorporates(IEnumerable<int> corporatesToDelete);
    }
}
