using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Corporates;

namespace Application.Corporates
{
    public interface ICorporateService
    {
        IEnumerable<Corporate> RetrieveCorporate();
        void SaveCorporate(Corporate model);
        Corporate RetrieveCorporateById(int id);
        void UpdateCorporate(Corporate model);
        void DeleteMultipleCorporates(IEnumerable<int> corporatesToDelete);
    }
}
