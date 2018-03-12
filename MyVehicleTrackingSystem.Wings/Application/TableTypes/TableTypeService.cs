using Domain.TableTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TableTypes
{
    public class TableTypeService : ITableTypeService
    {
        private ITableTypeRepository _repository;

        public IEnumerable<TableType> GetAllTableTypes()
        {
            return _repository.RetrieveTableTypes();
        }

    }
}
