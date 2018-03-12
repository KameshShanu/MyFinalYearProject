using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public interface IHelperService
    {
        Domain.Helper.Helper GetHelperById(int id);
        Domain.Helper.Helper GetUserByNic(string nic);
        IEnumerable<Domain.Helper.Helper> GetAllHelpers();
        void SaveHelper(Domain.Helper.Helper helper);
        void DeleteHelper(int id);
        void DeleteMultipleHelpers(IEnumerable<int> helpersToDelete);
        bool IsHelperExists(string epfNumber, string nic);
        void UpdateHelperAvailable(IEnumerable<int> helpersToUpdate);
        void UpdateHelperUnAvailable(IEnumerable<int> helpersToUpdate);
        void EditHelper(int id, Domain.Helper.Helper helper);
    }
}
