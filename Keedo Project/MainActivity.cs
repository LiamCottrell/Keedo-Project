using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.Datamodel;
using Keedo_Project.Resources.DialogControl;
using Keedo_Project.Resources.ImageAdapter;
using Square.Picasso;
using System;
using System.Collections.Generic;

namespace Keedo_Project
{
    [Activity(Label = "Keedo_Project", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button Clicker;
        private GridView TheGrid;
        private ImageView x;


        List<Inventory> y = new List<Inventory>();

        InventoryControl Inventory = new InventoryControl();
        DialogBox Dialogopen = new DialogBox();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Clicker = (Button)FindViewById(Resource.Id.OrdersButtonMain);
            TheGrid = (GridView)FindViewById(Resource.Id.Grid);

            TheGrid.ItemClick += Clicker_Click;

            onLoad();

        }

        public void Clicker_Click(object sender, AdapterView.ItemClickEventArgs e)
        { 
            View view = sender as View;
            Dialogopen.Popup(y[e.Position].Title, this);
        }
        async void onLoad()
        {

            //Intent intent = new Intent(this, typeof(ProductActivity));
            //this.StartActivity(intent);
            var x = await Inventory.SearchModule();
            y = x;
            TheGrid.Adapter = new ImageAdapter(this, y);
        }
    }

}

