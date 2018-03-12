using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Corporates
{
    public class Corporate : BaseEntity
    {
        public int CorporateId
        {
            get;
            set;
        }
        public string CorporateName
        {
            get;
            set;
        }
        public string CorporateDetails
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public override bool IsTransient()
        {
            return CorporateId == 0;
        }
    }
}
