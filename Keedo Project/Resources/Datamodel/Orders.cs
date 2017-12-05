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
    public class Orders
    {
        public int id { get; set; }
        public int buyer_id { get; set; }
        public int seller_id { get; set; }
        public bool collect_keedo { get; set; }
    }
}