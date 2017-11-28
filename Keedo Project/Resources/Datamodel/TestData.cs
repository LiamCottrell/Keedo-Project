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
    class InventoryTypes
    {
        //Model data so it matches my backend database
        public string Id { get; set; }
            
        public int ISBN { get; set; }

        public string Title { get; set; }
            
        public string Authors { get; set; }

        public string Publisher { get; set; }

        public int Year { get; set; }

        public string Language { get; set; }

        public string Price { get; set; }

        public string Cover { get; set; }

        public string Discription { get; set; }

        public int Quantity { get; set; }

    }
}