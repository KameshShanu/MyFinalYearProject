using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Invoice;
using DBStorage.Invoice;

namespace Application.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private InvoiceRepository _invoiceRepository;
        public InvoiceService(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IEnumerable<Domain.Invoice.Invoice> Retrieve()
        {
            return _invoiceRepository.Retrieve(null);
        }

        public Domain.Invoice.Invoice RetrieveById(int invoiceId)
        {
            return _invoiceRepository.RetrieveByKey(invoiceId);
        }

        public void SaveInvoice(Domain.Invoice.Invoice invoice)
        {
            _invoiceRepository.Save(invoice);
        }
    }
}
