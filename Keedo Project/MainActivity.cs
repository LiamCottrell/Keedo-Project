using Android.App;
using Android.OS;
using Android.Widget;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.DialogControl;
using System;

namespace Keedo_Project
{
    [Activity(Label = "Keedo_Project", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button Clicker;
        InventoryControl Inventory = new InventoryControl();
        DialogBox Dialogopen = new DialogBox();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Clicker = (Button)FindViewById(Resource.Id.OrdersButtonMain);

            Clicker.Click += ClickedItem;
        }

        async void ClickedItem(object sender, EventArgs e)
        {
            var value = await Inventory.SearchModule();

            Dialogopen.Popup(value[0].Title, this);



        }
    }
}

