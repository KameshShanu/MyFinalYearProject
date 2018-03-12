using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DispatchNote
{
    public interface IDispatchNoteRepository : IRepository<DispatchNote>
    {
        IEnumerable<DispatchNote> GetAllDispatchNote();
        IEnumerable<Domain.DispatchNote.DispatchNote> GetFilteredDispatchNote(DateTime? from, DateTime? to, string term);
        void DeleteMultipleDispatchNote(IEnumerable<int> DispatchNoteToDelete);
        int GenarateDispatchNumber();
        void SaveDispatchNote(DispatchNote DispatchNote);
        void UpdateDispatchNoteStatus(DispatchNote DispatchNote);
        void UpdateDispatchNote(DispatchNote DispatchNote);
        Domain.DispatchNote.DispatchNote GetDispatchNoteById(int id);
        void EditDispatchNote(int id, DispatchNote DispatchNote);
    }
}
