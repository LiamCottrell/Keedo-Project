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
    class Books
    {
            //Model data so it matches my backend database
            public string Id { get; set; }

            public string BookName { get; set; }

            public string BookPrice { get; set; }

    }
}