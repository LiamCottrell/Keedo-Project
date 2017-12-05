using Keedo_Project.Resources.Datamodel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Keedo_Project.Resources.Database
{
    class UserHandler
    {
        HttpClient client = new HttpClient();
        //List of web addresses to fetch data.

        public async Task<List<Users>> SearchTitle(string x)
        {
            var JsonData = await client.GetStringAsync("http://ec2-34-213-235-50.us-west-2.compute.amazonaws.com:3000/Users/select/search?title=" + x);
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Users>>(JsonData);
            return value;
        }

    }

}