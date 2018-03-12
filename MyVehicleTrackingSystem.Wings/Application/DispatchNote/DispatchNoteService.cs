using DBStorage.DispatchNote;
using Domain.DispatchNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DispatchNote
{
    public class DispatchNoteService : IDispatchNoteService
    {
        private IDispatchNoteRepository _dispatchNoteRepository;
        public DispatchNoteService(DispatchNoteRepository dispatchNoteRepository)
        {
            _dispatchNoteRepository = dispatchNoteRepository;
        }

        public void DeleteMultipleDispatchNote(IEnumerable<int> dispatchNoteToDelete)
        {
            _dispatchNoteRepository.DeleteMultipleDispatchNote(dispatchNoteToDelete);
        }

        public IEnumerable<Domain.DispatchNote.DispatchNote> GetFilteredDispatchNote(DateTime? from, DateTime? to, string term)
        {
            return _dispatchNoteRepository.GetFilteredDispatchNote(from, to, term);
        }

        public IEnumerable<Domain.DispatchNote.DispatchNote> GetAllDispatchNote()
        {
            return _dispatchNoteRepository.GetAllDispatchNote();
        }

        public Domain.DispatchNote.DispatchNote GetDispatchNoteById(int id)
        {
            return _dispatchNoteRepository.GetDispatchNoteById(id);
        }

        public void SaveDispatchNote(Domain.DispatchNote.DispatchNote dispatchNote)
        {
            _dispatchNoteRepository.SaveDispatchNote(dispatchNote);
        }

        public void UpdateDispatchNoteStatus(Domain.DispatchNote.DispatchNote dispatchNote)
        {
            _dispatchNoteRepository.UpdateDispatchNoteStatus(dispatchNote);
        }

        public void UpdateDispatchNote(Domain.DispatchNote.DispatchNote dispatchNote)
        {
            _dispatchNoteRepository.UpdateDispatchNote(dispatchNote);
        }

        public void EditDispatchNote(int id, Domain.DispatchNote.DispatchNote dispatchNote)
        {
            _dispatchNoteRepository.EditDispatchNote(id, dispatchNote);
        }

        public int GenarateDispatchNumber()
        {
            return _dispatchNoteRepository.GenarateDispatchNumber();
        }
    }
}
