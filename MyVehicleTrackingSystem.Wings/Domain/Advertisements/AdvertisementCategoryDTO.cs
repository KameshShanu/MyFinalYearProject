using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Advertisements
{
    public class AdvertisementCategoryDTO
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
        public string Error
        {
            get;
            set;
        }
        public IEnumerable<AdvertisementItemDTO> AdvertisementItem
        {
            get;
            set;
        }
    }
}
