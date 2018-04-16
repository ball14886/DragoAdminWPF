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
    public class DragoConnexProvider : BaseAPIProvider
    {
        public DragoConnexProvider()
            : base()
        {

        }

        public async Task<Uri> DeleteDragoConnexAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync("DragoConnex/" + id);
            return response.Headers.Location;
        }

        public async Task<List<DragoConnex>> GetDragoconnexesAsync(string path = "http://dragoservices.azurewebsites.net/api/DragoAdmin/DragoConnex/")
        {

            List<DragoConnex> m_siteList = new List<DragoConnex>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var DragoConnex = response.Content.ReadAsStringAsync().Result;
                m_siteList = JsonConvert.DeserializeObject<List<DragoConnex>>(DragoConnex);
            }
            else
            {
                return null;
            }
            return m_siteList;
        }

        public async Task<DragoConnex> CreateDragoConnexAsync(DragoConnex DragoConnex)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("DragoConnex", DragoConnex);
            var dragoConnex = new DragoConnex();
            if (response.IsSuccessStatusCode)
            {
                var dragoConnexResult = response.Content.ReadAsStringAsync().Result;
                dragoConnex = JsonConvert.DeserializeObject<DragoConnex>(dragoConnexResult);

                return dragoConnex;
            }
            return null;
        }

        public async Task<DragoConnex> GetDragoconnexAsync(string m_dragoConnexID)
        {
            string path = "http://dragoservices.azurewebsites.net/api/DragoAdmin/DragoConnex/" + m_dragoConnexID;
            DragoConnex m_dragoConnex = new DragoConnex();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var DragoConnex = response.Content.ReadAsStringAsync().Result;
                m_dragoConnex = JsonConvert.DeserializeObject<DragoConnex>(DragoConnex);
            }
            else
            {
                return null;
            }
            return m_dragoConnex;
        }
    }
}
