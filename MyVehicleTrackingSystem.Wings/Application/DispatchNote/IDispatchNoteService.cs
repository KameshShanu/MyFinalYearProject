using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DispatchNote
{
    public interface IDispatchNoteService
    {
        IEnumerable<Domain.DispatchNote.DispatchNote> GetAllDispatchNote();
        IEnumerable<Domain.DispatchNote.DispatchNote> GetFilteredDispatchNote(DateTime? from, DateTime? to, string term);
        void DeleteMultipleDispatchNote(IEnumerable<int> dispatchNoteToDelete);
        int GenarateDispatchNumber();
        void SaveDispatchNote(Domain.DispatchNote.DispatchNote dispatchNote);
        void UpdateDispatchNoteStatus(Domain.DispatchNote.DispatchNote dispatchNote);
        void UpdateDispatchNote(Domain.DispatchNote.DispatchNote dispatchNote);
        Domain.DispatchNote.DispatchNote GetDispatchNoteById(int id);
        void EditDispatchNote(int id, Domain.DispatchNote.DispatchNote dispatchNote);
    }
}
