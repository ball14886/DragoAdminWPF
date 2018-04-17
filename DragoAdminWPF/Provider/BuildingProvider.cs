using DragoAdminWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Provider
{
    public class BuildingProvider : BaseAPIProvider
    {
        public BuildingProvider() : base()
        {

        }

        public async Task<List<Area>> GetBuildingsAsync(string url = "http://dragoservices.azurewebsites.net/api/DragoAdmin/Areas/")
        {
            List<Area> m_buildingList = new List<Area>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var buildings = response.Content.ReadAsStringAsync().Result;
                m_buildingList = JsonConvert.DeserializeObject<List<Area>>(buildings);
            }
            else
            {
                return null;
            }
            return m_buildingList;
        }

        public async Task<Area> CreateBuildingAsync(Area building)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.PostAsJsonAsync("Areas", building);
            var area = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Area>(area);
        }

        public async Task<Uri> UpdateBuildingAsync(Area building)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("Areas", building);
            response.EnsureSuccessStatusCode();
            
            building = await response.Content.ReadAsAsync<Area>();
            return response.Headers.Location;
        }

        public async Task<HttpStatusCode> DeleteBuildingAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync("Areas/" + id);
            return response.StatusCode;
        }
    }
}
