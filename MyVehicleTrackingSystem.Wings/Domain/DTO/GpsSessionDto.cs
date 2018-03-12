using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GpsSessionDto
    {
        [JsonProperty(PropertyName = "result")]
        public string result { get; set; }

        [JsonProperty(PropertyName = "pid")]
        public string pid { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string error_code { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string error { get; set; }
    }
}
