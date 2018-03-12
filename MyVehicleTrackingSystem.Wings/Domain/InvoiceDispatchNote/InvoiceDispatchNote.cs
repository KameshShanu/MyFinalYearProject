using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InvoiceDispatchNote
{
    public class InvoiceDispatchNote : BaseEntity
    {
        public int InvoiceDispatchNoteId
        {
            get;
            set;
        }

        public int DispatchNoteId
        {
            get;
            set;
        }

        public int InvoiceId
        {
            get;
            set;
        }

        public string Driver
        {
            get;
            set;
        }

        public string Helper
        {
            get;
            set;
        }

        public string Client
        {
            get;
            set;
        }

        public string CompanyAddress
        {
            get;
            set;
        }

        public string VehicleLicensePlateNumber
        {
            get;
            set;
        }

        public string Quantity
        {
            get;
            set;
        }

        public string VehicleDeliveryType
        {
            get;
            set;
        }

        public DateTime DispatchDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string DispatchId
        {
            get;
            set;
        }

        public decimal ClientRate
        {
            get;
            set;
        }

        public decimal DriverCommissionRate
        {
            get;
            set;
        }

        public decimal PorterCommissionRate
        {
            get;
            set;
        }

        public bool IsDispatchNoteReceived
        {
            get;
            set;
        }

        public bool IsGoodsDelivered
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public bool IsPrinted
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public virtual Invoice.Invoice Invoice
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return InvoiceDispatchNoteId == 0;
        }
    }
}
