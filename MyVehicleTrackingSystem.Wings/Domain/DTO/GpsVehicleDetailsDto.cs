using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GpsVehicleDetailsDto
    {
        [JsonProperty(PropertyName = "result")]
        public string result { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int count { get; set; }

        [JsonProperty(PropertyName = "device_id")]
        public string device_id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "meter_reading")]
        public string meter_reading { get; set; }

        [JsonProperty(PropertyName = "fuel_level")]
        public string fuel_level { get; set; }

        [JsonProperty(PropertyName = "last_update")]
        public string last_update { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string error_code { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string error { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string lat { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public string lon { get; set; }

    }
}
