using System.Collections.Generic;
using Domain.BataRates;
using DBStorage.BataRates;
using System;

namespace Application.BataRates
{
    public class BataRateService : IBataRateService
    {

        private IBataRepository _bataResitory;

        public BataRateService(BataRateRepository bataRepository)
        {
            _bataResitory = bataRepository;
        }

        public void DeleteMultipleBataRates(IEnumerable<int> bataRateToDelete)
        {
            _bataResitory.DeleteMultipleBataRates(bataRateToDelete);
        }

        public IEnumerable<BataRate> GetAllBataRates()
        {
            return _bataResitory.GetAllBataRates();
        }

        public BataRate GetBataRateById(int bataRateId)
        {
            return _bataResitory.RetrieveByKey(bataRateId);
        }

        public void SaveBataRates(BataRate model)
        {
            _bataResitory.SaveBataRates(model);
        }
    }
}
