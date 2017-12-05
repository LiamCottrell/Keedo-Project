using Keedo_Project.Resources.Datamodel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Keedo_Project.Resources.Database
{
    class BookHandler
    {
        HttpClient client = new HttpClient();
        //List of web addresses to fetch data.

        public async Task<List<Books>> SearchTitle(string x)
        {
            var JsonData = await client.GetStringAsync("http://ec2-34-213-235-50.us-west-2.compute.amazonaws.com:3000/books/select/search?title=" + x);
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Books>>(JsonData);
            return value;
        }

    }

}