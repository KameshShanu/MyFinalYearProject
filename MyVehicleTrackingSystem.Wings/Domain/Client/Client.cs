using Domin.Common;

namespace Domain.Client
{
    public class Client : BaseEntity
    {
        public int ClientId
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public string CompanyAddress
        {
            get;
            set;
        }

        public string PhoneNumber1
        {
            get;
            set;
        }

        public string PhoneNumber2
        {
            get;
            set;
        }

        public string VAT
        {
            get;
            set;
        }

        public string SVAT
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

        public string OperationType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return ClientId == 0;
        }
    }
}
