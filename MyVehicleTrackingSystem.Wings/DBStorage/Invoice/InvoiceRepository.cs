using DBStorage.Common;
using Domain.DispatchNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Common;
using System.Linq.Expressions;
using Domain.Invoice;

namespace DBStorage.Invoice
{
    public class InvoiceRepository : Repository<Domain.Invoice.Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(WingsContext context) : base(context)
        {
        }
    }
}
