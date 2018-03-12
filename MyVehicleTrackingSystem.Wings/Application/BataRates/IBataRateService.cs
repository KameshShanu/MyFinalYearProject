using Domain.BataRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BataRates
{
    public interface IBataRateService
    {
        IEnumerable<BataRate> GetAllBataRates();
        BataRate GetBataRateById(int bataRateId);
        void SaveBataRates(BataRate model);
        void DeleteMultipleBataRates(IEnumerable<int> bataRateToDelete);
    }
}
