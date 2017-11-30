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
using Newtonsoft.Json;

namespace Keedo_Project.Resources.Datamodel
{
    //public class DataContainer
    //{
    //    public List<Inventory> Inventory { get; set; }
    //}

    public class Inventory
    {
        //Model data so it matches my backend database
 
        [JsonProperty("ISBN")]
        public string ISBN { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Authors")]
        public string Authors { get; set; }

        [JsonProperty("Publisher")]
        public string Publisher { get; set; }

        [JsonProperty("Year")]
        public String Year { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Cover")]
        public string Cover { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Quantity")]
        public String Quantity { get; set; }

        //[JsonProperty("Status")]
        //public int Status { get; set; }

        //[JsonProperty("Module")]
        //public string Module { get; set; }

    }
}