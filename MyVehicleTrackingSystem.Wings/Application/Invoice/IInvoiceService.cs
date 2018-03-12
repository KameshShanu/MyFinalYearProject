using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice
{
    public interface IInvoiceService
    {
        IEnumerable<Domain.Invoice.Invoice> Retrieve();
        Domain.Invoice.Invoice RetrieveById(int invoiceId);
        void SaveInvoice(Domain.Invoice.Invoice invoice);
    }
}
