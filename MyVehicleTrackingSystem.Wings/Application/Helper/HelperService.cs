using System;
using System.Collections.Generic;
using Domain.Helper;
using DBStorage.Helper;
using System.Linq;

namespace Application.Helper
{
    public class HelperService : IHelperService
    {
        private IHelperRepository _helperRepository;
        public HelperService(HelperRepository helperRepository)
        {
            _helperRepository = helperRepository;
        }

        public void DeleteHelper(int id)
        {
            Domain.Helper.Helper helper = GetHelperById(id);

            if (helper != null)
            {
                _helperRepository.Delete(helper);
                _helperRepository.SaveHelper(helper);
            }
        }

        public void DeleteMultipleHelpers(IEnumerable<int> helpersToDelete)
        {
            _helperRepository.DeleteMultipleHelpers(helpersToDelete);
        }

        public void EditHelper(int id, Domain.Helper.Helper helper)
        {
            _helperRepository.EditHelper(id, helper);
        }

        public IEnumerable<Domain.Helper.Helper> GetAllHelpers()
        {
            return _helperRepository.GetAllHelpers();
        }

        public Domain.Helper.Helper GetHelperById(int id)
        {
            return _helperRepository.GetHelperById(id);
        }

        public Domain.Helper.Helper GetUserByNic(string nic)
        {
            return _helperRepository.GetUserByNic(nic);
        }

        public bool IsHelperExists(string epfNumber, string nic)
        {
            return _helperRepository.IsHelperExists(epfNumber, nic);
        }

        public void SaveHelper(Domain.Helper.Helper helper)
        {
            _helperRepository.SaveHelper(helper);
        }

        public void UpdateHelperAvailable(IEnumerable<int> helpersToUpdate)
        {
            _helperRepository.UpdateHelperAvailable(helpersToUpdate);
        }

        public void UpdateHelperUnAvailable(IEnumerable<int> helpersToUpdate)
        {
            _helperRepository.UpdateHelperUnAvailable(helpersToUpdate);
        }
    }
}
