using Android.App;
using Android.OS;
using Android.Widget;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.Datamodel;
using Keedo_Project.Resources.DialogControl;
using Square.Picasso;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Keedo_Project
{
    [Activity(Label = "Keedo_Project", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ImageButton test;
        private Button Clicker;
        InventoryControl Inventory = new InventoryControl();
        DialogBox Dialogopen = new DialogBox();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            test = (ImageButton)FindViewById(Resource.Id.BasketButtonMain);
            Clicker = (Button)FindViewById(Resource.Id.OrdersButtonMain);

            Clicker.Click += ClickedItem;
        }

        async void ClickedItem(object sender, EventArgs e)
        {
            string x = "";
            var value = await Inventory.SearchModule();
            Picasso.With(this)
                .Load(value[0].Cover)
                .Into(test);
            Dialogopen.Popup(value[0].Title, this);


        }
    }
}

