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

    public class Books
    {
        public object isbn { get; set; }
        public string title { get; set; }
        public string authors { get; set; }
        public string publisher { get; set; }
        public int year { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
    }
}