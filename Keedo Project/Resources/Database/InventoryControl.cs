using Keedo_Project.Resources.Datamodel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Keedo_Project.Resources.Database
{
    class InventoryControl
    {
        HttpClient client = new HttpClient();
        //List of web addresses to fetch data.

        public async Task<List<Inventory>> SearchModule(string x)
        {
            var JsonData = await client.GetStringAsync(x);
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inventory>>(JsonData);
            return value;
        }

        //public async Task SearchTitleAsync()
        //{
        //    var value = await client.GetStringAsync("");
        //    return value;
        //}

        //public async Task<> GetLatestAsync()
        //{
        //    var value = await client.GetStringAsync("");
        //    return value;
        //}

        //public void Push()
        //{

        //}

    }

}