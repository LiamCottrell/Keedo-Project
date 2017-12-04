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
        private SearchView SearchBox;
        private GridView TheGrid;


        List<Inventory> InventoryList = new List<Inventory>();

        InventoryControl Inventory = new InventoryControl();
        DialogBox Dialogopen = new DialogBox();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SearchBox = (SearchView)FindViewById(Resource.Id.SearchBar);
            TheGrid = (GridView)FindViewById(Resource.Id.Grid);

            SearchBox.SetQueryHint("Search For A Book!");

            SearchBox.QueryTextSubmit += (s, e) => example();

            TheGrid.ItemClick += Grid_Clicked;

            onLoad();

        }


        void example()
        {
            Toast.MakeText(this, SearchBox.Query, ToastLength.Long).Show();
        }

        public void Grid_Clicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            
            var BookSelected = Newtonsoft.Json.JsonConvert.SerializeObject(InventoryList[e.Position]);

            View view = sender as View;

            Intent intent = new Intent(this, typeof(ProductActivity));
            intent.PutExtra("Book Selected",BookSelected);
            this.StartActivity(intent);
        }
        async void onLoad()
        {
            var x = await Inventory.SearchModule();
            InventoryList = x;
            TheGrid.Adapter = new ImageAdapter(this, InventoryList);
        }

        
    }

}

