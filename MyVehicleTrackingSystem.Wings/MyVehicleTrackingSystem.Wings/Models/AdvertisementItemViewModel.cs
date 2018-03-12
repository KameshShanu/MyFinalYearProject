using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class AdvertisementItemViewModel
    {
        public int ItemId
        {
            get;
            set;
        }
        public int CategoryId
        {
            get;
            set;
        }
        [DisplayName("Advertisement Name")]
        public string ItemName
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
        public string FileURL
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
    }
}