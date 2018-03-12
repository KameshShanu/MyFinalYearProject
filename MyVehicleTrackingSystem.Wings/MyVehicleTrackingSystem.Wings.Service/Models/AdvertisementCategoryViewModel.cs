using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class AdvertisementCategoryViewModel
    {
        public int CategoryId
        {
            get;
            set;
        }
        [DisplayName("Advertisement Name")]
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

        [DisplayName("Upload File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase UploadFile { get; set; }
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
        [DisplayName("Upload File")]
        public string FileURL
        {
            get;
            set;
        }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz}")]
        public DateTime? CreatedDate
        {
            get;
            set;
        }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz}")]
        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public IEnumerable<AdvertisementItemViewModel> AdvertisementItem
        {
            get;
            set;
        }
    }
}