using Domin.Common;
using System.Collections.Generic;

namespace Domain.Helper
{
    public interface IHelperRepository : IRepository<Helper>
    {
        IEnumerable<Helper> GetAllHelpers();
        void DeleteMultipleHelpers(IEnumerable<int> helpersToDelete);
        bool IsHelperExists(string empNumber, string nic);
        void SaveHelper(Helper helper);
        void UpdateHelperAvailable(IEnumerable<int> helpersToUpdate);
        void UpdateHelperUnAvailable(IEnumerable<int> helpersToUpdate);
        Domain.Helper.Helper GetHelperById(int id);
        Domain.Helper.Helper GetUserByNic(string nic);
        void EditHelper(int id, Domain.Helper.Helper helper);
    }
}
