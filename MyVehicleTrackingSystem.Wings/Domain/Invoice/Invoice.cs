using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoice
{
    public class Invoice : BaseEntity
    {
        public int InvoiceId
        {
            get;
            set;
        }

        public string InvoiceType
        {
            get;
            set;
        }

        public string SVAT
        {
            get;
            set;
        }

        public string VAT
        {
            get;
            set;
        }

        public string InvoiceDate
        {
            get;
            set;
        }

        public string InvoiceNumber
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public decimal TotalValue
        {
            get;
            set;
        }

        public decimal SVATAmount
        {
            get;
            set;
        }

        public decimal VATAmount
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public virtual ICollection<InvoiceDispatchNote.InvoiceDispatchNote> InvoiceDispatchNote
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return InvoiceId == 0;
        }
    }
}
