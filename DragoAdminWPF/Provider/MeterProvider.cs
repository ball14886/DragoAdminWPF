using DragoAdminWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Provider
{
    public class MeterProvider : BaseAPIProvider
    {
        public MeterProvider()
            : base()
        {

        }

        public async Task<List<Meter>> GetMetersAsync(string url = "http://dragoservices.azurewebsites.net/api/DragoAdmin/Meters/")
        {
            List<Meter> m_meterList = new List<Meter>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var Meter = response.Content.ReadAsStringAsync().Result;
                m_meterList = JsonConvert.DeserializeObject<List<Meter>>(Meter);
            }
            else
            {
                return null;
            }
            return m_meterList;
        }

        public async Task<Uri> UpdateMeterAsync(Meter meter)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("Meters", meter);
            response.EnsureSuccessStatusCode();

            meter = await response.Content.ReadAsAsync<Meter>();
            return response.Headers.Location;
        }

        public async Task<Uri> CreateMeterAsync(Meter meter)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("Meters", meter);
            return response.Headers.Location;
        }

        public async Task<Uri> DeleteMeterAsync(Guid id)
        {
            HttpResponseMessage response = await client.DeleteAsync("Meters/" + id);
            return response.Headers.Location;
        }

        public async Task<Meter> GetMeterAsync(Guid meterID)
        {
            var url = "http://dragoservices.azurewebsites.net/api/DragoAdmin/Meters/" + meterID;
            List<Meter> m_meterList = new List<Meter>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var Meter = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Meter>(Meter);
            }
            else
            {
                return null;
            }

        }

        public async Task<Uri> UpdateMeterAsync(string oldID, Meter meter)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("Meters/?oldID=" + oldID, meter);
            // response.EnsureSuccessStatusCode();

            meter = await response.Content.ReadAsAsync<Meter>();
            return response.Headers.Location;
        }

        public async Task<Uri> CreateMeterRangeAsync(List<Meter> meterList)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("Meters/Range", meterList);
            return response.Headers.Location;
        }
    }
}
