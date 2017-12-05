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

namespace Keedo_Project.Resources.Datamodel
{
    public class Offers
    {
        public int id { get; set; }
        public object isbn { get; set; }
        public int user_id { get; set; }
        public double price { get; set; }
        public bool completed { get; set; }
    }
}