using DBStorage.Common;
using Domain.DispatchNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.DispatchNote
{
    public class DispatchNoteRepository : Repository<Domain.DispatchNote.DispatchNote>, IDispatchNoteRepository
    {
        public DispatchNoteRepository(WingsContext context) : base(context)
        {

        }

        public void DeleteMultipleDispatchNote(IEnumerable<int> dispatchNoteToDelete)
        {
            Context.DispatchNote.Where(d => dispatchNoteToDelete.Contains(d.DispatchNoteId)).ToList().ForEach(
                 d =>
                 {
                     d.IsDeleted = true;
                 }
                 );
            Context.Commit();
        }

        public int GenarateDispatchNumber()
        {
            return (Context.DispatchNote.OrderByDescending(d => d.DispatchNoteId).Select(d => d.DispatchNoteId).FirstOrDefault() + 1);
        }

        public IEnumerable<Domain.DispatchNote.DispatchNote> GetAllDispatchNote()
        {
            return Retrieve(d => d.IsDeleted == false);
        }

        public IEnumerable<Domain.DispatchNote.DispatchNote> GetFilteredDispatchNote(DateTime? from, DateTime? to, string term)
        {
            if ((from.HasValue && to.HasValue) && !string.IsNullOrEmpty(term))
            {
                return Context.DispatchNote.Where(d => d.Status == "Open" && d.IsDeleted == false && (d.DispatchDate >= from && d.DispatchDate <= to) && (d.DispatchId.Contains(term) || d.Client.Contains(term) || d.Quantity.Contains(term) || d.Driver.Contains(term) || d.VehicleLicensePlateNumber.Contains(term)));
            }

            if ((from.HasValue || to.HasValue) && !string.IsNullOrEmpty(term))
            {
                return Context.DispatchNote.Where(d => d.Status == "Open" && d.IsDeleted == false && (d.DispatchDate == from || d.DispatchDate == to) && (d.DispatchId.Contains(term) || d.Client.Contains(term) || d.Quantity.Contains(term) || d.Driver.Contains(term) || d.VehicleLicensePlateNumber.Contains(term)));
            }

            if (from.HasValue && to.HasValue)
            {
                return Context.DispatchNote.Where(d => d.Status == "Open" && d.IsDeleted == false && (d.DispatchDate >= from && d.DispatchDate <= to));
            }

            if (from.HasValue || to.HasValue)
            {
                return Context.DispatchNote.Where(d => d.Status == "Open" && d.IsDeleted == false && (d.DispatchDate == from || d.DispatchDate == to));
            }

            return Context.DispatchNote.Where(d => d.Status == "Open" && d.IsDeleted == false && (d.DispatchId.Contains(term) || d.Client.Contains(term) || d.Quantity.Contains(term) || d.Driver.Contains(term) || d.VehicleLicensePlateNumber.Contains(term)));
        }

        public Domain.DispatchNote.DispatchNote GetDispatchNoteById(int id)
        {
            return Retrieve(d => d.DispatchNoteId == id).SingleOrDefault();
        }

        public void SaveDispatchNote(Domain.DispatchNote.DispatchNote DispatchNote)
        {
            Save(DispatchNote);
        }

        public void UpdateDispatchNoteStatus(Domain.DispatchNote.DispatchNote DispatchNote)
        {
            Domain.DispatchNote.DispatchNote dispatchNoteFromdb = RetrieveByKey(DispatchNote.DispatchNoteId);
            if(dispatchNoteFromdb != null)
            {
                dispatchNoteFromdb.Status = DispatchNote.Status;
                dispatchNoteFromdb.IsDispatchNoteReceived = DispatchNote.IsDispatchNoteReceived;
                dispatchNoteFromdb.IsGoodsDelivered = DispatchNote.IsGoodsDelivered;
                dispatchNoteFromdb.Remarks = DispatchNote.Remarks;
                Save(dispatchNoteFromdb);
            }
        }

        public void UpdateDispatchNote(Domain.DispatchNote.DispatchNote DispatchNote)
        {
            Domain.DispatchNote.DispatchNote dispatchNoteFromdb = RetrieveByKey(DispatchNote.DispatchNoteId);
            if(dispatchNoteFromdb != null)
            {
                dispatchNoteFromdb.Client = DispatchNote.Client;
                dispatchNoteFromdb.DriverCommissionRate = DispatchNote.DriverCommissionRate;
                dispatchNoteFromdb.PorterCommissionRate = DispatchNote.PorterCommissionRate;
                dispatchNoteFromdb.ClientRate = DispatchNote.ClientRate;                
                dispatchNoteFromdb.CompanyAddress = DispatchNote.CompanyAddress;
                dispatchNoteFromdb.VehicleLicensePlateNumber = DispatchNote.VehicleLicensePlateNumber;
                dispatchNoteFromdb.Quantity = DispatchNote.Quantity;
                dispatchNoteFromdb.VehicleDeliveryType = DispatchNote.VehicleDeliveryType;
                dispatchNoteFromdb.Driver = DispatchNote.Driver;
                dispatchNoteFromdb.Helper = DispatchNote.Helper;
                dispatchNoteFromdb.DispatchDate = DispatchNote.DispatchDate;
                dispatchNoteFromdb.IsPrinted = DispatchNote.IsPrinted;
                Save(dispatchNoteFromdb);
            }          
        }

        public void EditDispatchNote(int id, Domain.DispatchNote.DispatchNote DispatchNote)
        {
            Domain.DispatchNote.DispatchNote vm = RetrieveByKey(id);

            vm.DispatchDate = DispatchNote.DispatchDate;            
            Save(vm);
        }
    }
}
