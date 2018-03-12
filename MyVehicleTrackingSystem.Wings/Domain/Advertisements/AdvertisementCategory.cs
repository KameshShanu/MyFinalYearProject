using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Advertisements
{
    public class AdvertisementCategory : BaseEntity
    {
        public int CategoryId
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public string FileURL
        {
            get;
            set;
        }
        public string FileType
        {
            get;
            set;
        }
        public string CreatedDate
        {
            get;
            set;
        }
        public string ModifiedDate
        {
            get;
            set;
        }
        public bool IsModified
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public virtual List<AdvertisementItem> AdvertisementItem
        {
            get;
            set;
        }
        public override bool IsTransient()
        {
            return CategoryId == 0;
        }
    }
}
