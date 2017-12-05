using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Apis.Books.v1;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.Datamodel;
using Keedo_Project.Resources.DialogControl;
using Keedo_Project.Resources.ImageAdapter;
using Square.Picasso;
using System;
using System.Collections.Generic;
using ZXing;
using ZXing.Mobile;

namespace Keedo_Project
{
    [Activity(Label = "Keedo_Project", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private SearchView SearchBox;
        private GridView TheGrid;
        private Button BarButton;

        List<Inventory> InventoryList = new List<Inventory>();

        InventoryControl Inventory = new InventoryControl();
        BookFinder Book = new BookFinder();
        DialogBox Dialogopen = new DialogBox();
        BooksService bookservice = new BooksService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SearchBox = (SearchView)FindViewById(Resource.Id.SearchBar);
            TheGrid = (GridView)FindViewById(Resource.Id.Grid);
            BarButton = (Button)FindViewById(Resource.Id.ScanButton);

            SearchBox.SetQueryHint("Search For A Book!");

            SearchBox.QueryTextSubmit += (s, e) => exampleAsync();

            BarButton.Click += BarReader_Click;
            TheGrid.ItemClick += Grid_Clicked;

            onLoad();

            MobileBarcodeScanner.Initialize(Application);

        }

        void HandleResult(ZXing.Result result)
        {
            var msg = "No Barcode!";

            if (result != null)
            {
                msg = "Barcode: " + result.Text + " (" + result.BarcodeFormat + ")";
            }

            Toast.MakeText(this, msg, ToastLength.Long).Show();
        }

        async void BarReader_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var scanner = new MobileBarcodeScanner();
            //    var result = await scanner.Scan();
            //}
            //catch (Exception ex)
            //{
            //    Dialogopen.Popup(ex.ToString(), this);
            //}
                string isbn = "9780080966748";
                var x = await Book.SearchModule(isbn);
            Dialogopen.Popup(x.items[0].volumeInfo.title, this);

        }


        async void exampleAsync()
        {
            InventoryList.Clear();
            string QueryString = "http://ec2-34-213-235-50.us-west-2.compute.amazonaws.com:3000/books/select/search?title=" + SearchBox.Query;
            var Results = await Inventory.SearchModule(QueryString);
            InventoryList = Results;
            TheGrid.RemoveAllViewsInLayout();
            TheGrid.Adapter = new ImageAdapter(this, InventoryList);
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(SearchBox.WindowToken, 0);

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
            var x = await Inventory.SearchModule("http://ec2-34-213-235-50.us-west-2.compute.amazonaws.com:3000/books/select/");
            InventoryList.Add(x[0]);
            InventoryList.Add(x[1]);
            TheGrid.Adapter = new ImageAdapter(this, InventoryList);
        }

        
    }

}

