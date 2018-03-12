using DBStorage.Common;
using Domain.DTO;
using Domain.GPS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBStorage.GPS
{
    public class GpsRepository : WebClientWrapperBase, IGpsRepository
    {
        public GpsRepository()
            : base("http://universaltrackers.com/api_utrack/?")
        {
            //just for compatibility
        }

        public GpsRepository(string baseUrl)
            : base(baseUrl)
        {
        }

        public async Task<GpsVehicleDetailsDto> GpsMeterReading(string vehicleNo)
        {
            GpsVehicleDetailsDto responseobj = new GpsVehicleDetailsDto();
            GpsSessionDto sessionobj = new GpsSessionDto();
            string baseURL = "http://universaltrackers.com/api_utrack/?";
            string userloginUrl = "SID=100&UN=testlog@hypercent.com&PS=abc123";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    CancellationTokenSource cts = new CancellationTokenSource(10000); // 10 seconds

                    using (HttpResponseMessage response = await client.GetAsync(baseURL + userloginUrl, cts.Token))
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            sessionobj = JsonConvert.DeserializeObject<IEnumerable<GpsSessionDto>>(result).FirstOrDefault();
                        }
                    };
                    string vehiDetails = "SID=102&VTEXT=" + vehicleNo.Replace(" ", String.Empty).Replace(@"-", String.Empty) + "&PID=" + sessionobj.pid + "";
                    using (HttpResponseMessage response = await client.GetAsync(baseURL + vehiDetails, cts.Token))
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            responseobj = JsonConvert.DeserializeObject<IEnumerable<GpsVehicleDetailsDto>>(result).LastOrDefault();
                        }
                    }
                }
                return responseobj;
            }
            catch (Exception ex)
            {
                responseobj.error = "Error retrieving meter reading";
                return responseobj;
            }
        }
    }
}
