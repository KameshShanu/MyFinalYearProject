using System.Collections.Generic;
using DBStorage.Common;
using Domain.Helper;
using System.Linq;
using System.Data;

namespace DBStorage.Helper
{
    public class HelperRepository : Repository<Domain.Helper.Helper>, IHelperRepository
    {
        public HelperRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultipleHelpers(IEnumerable<int> helpersToDelete)
        {
            Context.Helper.Where(d => helpersToDelete.Contains(d.HelperId)).ToList().ForEach(
                d =>
                {
                    d.IsDeleted = true;
                }
                );
            Context.Commit();
        }

        public void EditHelper(int id, Domain.Helper.Helper helper)
        {
            Domain.Helper.Helper helperToBeEdited = RetrieveByKey(id);

            helperToBeEdited.EPFNumber = helper.EPFNumber;
            helperToBeEdited.Name = helper.Name;          
            helperToBeEdited.PhoneNumber2 = helper.PhoneNumber2;
            helperToBeEdited.NIC = helper.NIC;
            helperToBeEdited.DateOfBirth = helper.DateOfBirth;
            helperToBeEdited.ResidentAddress = helper.ResidentAddress;
            helperToBeEdited.PhoneNumber1 = helper.PhoneNumber1;
            helperToBeEdited.PhoneNumber2 = helper.PhoneNumber2;
            helperToBeEdited.StartDateOfWork = helper.StartDateOfWork;
            helperToBeEdited.PeriodOfService = helper.PeriodOfService;
            helperToBeEdited.BasicSalary = helper.BasicSalary;
            helperToBeEdited.MinimumSalary = helper.MinimumSalary;
            helperToBeEdited.PoliceReportExpiryDate = helper.PoliceReportExpiryDate;
            Save(helperToBeEdited);
        }

        public IEnumerable<Domain.Helper.Helper> GetAllHelpers()
        {
            return Retrieve(f => f.IsDeleted == false);
        }

        public Domain.Helper.Helper GetHelperById(int id)
        {
            return Retrieve(a => a.HelperId == id).SingleOrDefault();
        }

        public Domain.Helper.Helper GetUserByNic(string nic)
        {
            return Retrieve(a => a.NIC == nic).SingleOrDefault();
        }

        public bool IsHelperExists(string epfNumber, string nic)
        {
            return !Context.Helper.Any(x => (x.EPFNumber == epfNumber || x.NIC == nic) && x.IsDeleted.Equals(false));
        }

        public void SaveHelper(Domain.Helper.Helper helper)
        {
            Save(helper);
        }

        public void UpdateHelperAvailable(IEnumerable<int> helpersToUpdate)
        {
            Context.Helper.Where(d => helpersToUpdate.Contains(d.HelperId)).ToList().ForEach(d => d.IsAvailable = false);
            Context.Commit();
        }

        public void UpdateHelperUnAvailable(IEnumerable<int> helpersToUpdate)
        {
            Context.Helper.Where(d => helpersToUpdate.Contains(d.HelperId)).ToList().ForEach(d => d.IsAvailable = true);
            Context.Commit();
        }
    }
}
