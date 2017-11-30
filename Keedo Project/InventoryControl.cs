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
using System.Net;
using System.IO;
using System.Json;
using Keedo_Project.Resources.Datamodel;
using System.Collections.ObjectModel;

namespace Keedo_Project.Resources.Database
{
    class InventoryControl
    {
        HttpClient client = new HttpClient();
        //List of web addresses to fetch data.
        //Search By Module//
        //Search By Title
        //Search Two latest books.
        //
        

        public async Task<List<Inventory>>  SearchModule()
        {
            var JsonData = await client.GetStringAsync("http://ec2-34-213-235-50.us-west-2.compute.amazonaws.com:3000/inv");
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