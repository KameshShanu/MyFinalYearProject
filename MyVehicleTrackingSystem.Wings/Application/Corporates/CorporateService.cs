using DBStorage.Corporates;
using Domain;
using Domain.Corporates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Corporates
{ 
    public class CorporateService : ICorporateService
    {
        private ICorporateRepository _repository;
        public CorporateService(CorporateRepository repository)
        {
            _repository = repository;
        }

        public void DeleteMultipleCorporates(IEnumerable<int> corporatesToDelete)
        {
            _repository.DeleteMultipleCorporates(corporatesToDelete);
        }

        public IEnumerable<Corporate> RetrieveCorporate()
        {
            return _repository.RetrieveCorporate();
        }

        public Corporate RetrieveCorporateById(int id)
        {
            return _repository.RetrieveCorporateById(id);
        }

        public void SaveCorporate(Corporate model)
        {
            _repository.SaveCorporate(model);
        }

        public void UpdateCorporate(Corporate model)
        {
             _repository.UpdateCorporate(model);
        }
    }
}
