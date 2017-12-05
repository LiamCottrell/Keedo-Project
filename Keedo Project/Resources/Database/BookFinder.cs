using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Keedo_Project.Resources.Datamodel;
using FasterXml.Jackson.Core;

namespace Keedo_Project.Resources.Database
{
    class BookFinder
    {
        HttpClient client = new HttpClient();
        //List of web addresses to fetch data.

        public async Task<BookJson> SearchGoogleAPI(string x)
        {
            var JsonData = await client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=isbn:" + x);
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<BookJson>(JsonData);
            return value;
        }
    }
}