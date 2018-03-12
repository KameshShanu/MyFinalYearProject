using Domain.TableTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TableTypes
{
    public interface ITableTypeService
    {
        IEnumerable<TableType> GetAllTableTypes();
    }
}
