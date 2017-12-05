using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Webkit;
using Android.Widget;
using Google.Apis.Books.v1;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.Datamodel;
using Keedo_Project.Resources.DialogControl;
using Keedo_Project.Resources.ImageAdapter;
using Square.Picasso;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        List<Books> BookList = new List<Books>();

        BookHandler Inventory = new BookHandler();
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

            SearchBox.QueryTextSubmit += (s, e) => PopulateSearch();

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
            //var scanner = new MobileBarcodeScanner();
            //var result = await scanner.Scan();

            //string isbn = "9780080966748";
            //    var x = await Book.SearchModule(isbn);
            //Dialogopen.Popup(x.items[0].volumeInfo.title, this);

        }


        async void PopulateSearch()
        {

            string QueryString =  SearchBox.Query;
            var Results = await Inventory.SearchTitle(QueryString);

            if (Results.Count > 0)
            {
                BookList.Clear();
                BookList = Results;

                TheGrid.RemoveAllViewsInLayout();
                TheGrid.Adapter = new ImageAdapter(this, BookList);

                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(SearchBox.WindowToken, 0);
            }
            else
            {
                CheckAmazon();
            }


        }

        private void CheckAmazon()
        {
            //Create our new dialog variable and pass the builder context for building it.
            var Alert = new AlertDialog.Builder(this);
            //Set our message as the passed in x variable
            Alert.SetMessage("We are unable to find this book in our database, would you like to check Amazon?");

            Alert.SetPositiveButton("Yes", LoadAmazon);
            //Set the neutural click button text
            Alert.SetNegativeButton("No", delegate { });
            //Display built alert to user.
            Alert.Show();
        }

        private void LoadAmazon(object sender, DialogClickEventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://www.amazon.co.uk/s/ref=nb_sb_noss_2?url=search-alias%3Dstripbooks&field-keywords=" + SearchBox.Query + "&rh=n%3A266239%2Ck%3A" + SearchBox.Query);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }


        public void Grid_Clicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            
            var BookSelected = Newtonsoft.Json.JsonConvert.SerializeObject(BookList[e.Position]);

            View view = sender as View;

            Intent intent = new Intent(this, typeof(ProductActivity));
            intent.PutExtra("Book Selected",BookSelected);
            this.StartActivity(intent);
        }

        async void onLoad()
        {
            var x = await Inventory.SearchTitle("");
            BookList.Add(x[0]);
            BookList.Add(x[1]);
            TheGrid.Adapter = new ImageAdapter(this, BookList);
        }

        
    }

}

