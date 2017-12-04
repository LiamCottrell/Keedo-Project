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
using Keedo_Project.Resources.DialogControl;
using Keedo_Project.Resources.Database;
using Keedo_Project.Resources.Datamodel;
using Square.Picasso;

namespace Keedo_Project
{
    [Activity(Label = "ProductActivity")]
    public class ProductActivity : Activity
    {

        private TextView BookDescription;
        private Button BuyButton;
        private RadioGroup RadioChoice;
        private TextView BookTitle;
        private ImageView BookImage;
        private TextView BookPrice;
        private TextView Author;
        private string BookSelectedUnParsed;
        private Inventory BookSelected;

        DialogBox Alert = new DialogBox();
        InventoryControl Inventory = new InventoryControl();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Product);

            BookDescription = (TextView)FindViewById(Resource.Id.BookInfo);
            BuyButton = (Button)FindViewById(Resource.Id.BuyBook);
            RadioChoice = (RadioGroup)FindViewById(Resource.Id.radioGroup1);
            BookTitle = (TextView)FindViewById(Resource.Id.BookTitle);
            BookImage = (ImageView)FindViewById(Resource.Id.ExampleImage);
            BookPrice = (TextView)FindViewById(Resource.Id.BookPrice);
            Author = (TextView)FindViewById(Resource.Id.AuthorName);

            BookSelectedUnParsed = Intent.GetStringExtra("Book Selected");


            BookSelected = Newtonsoft.Json.JsonConvert.DeserializeObject<Inventory>(BookSelectedUnParsed);

            PopulateBook();

        }

        void PopulateBook()
        {

            BookTitle.Text = BookSelected.Title;
            BookPrice.Text = "£" + BookSelected.Price;
            BookDescription.Text = BookSelected.Description;
            Author.Text = BookSelected.Authors;
            if (BookSelected.Cover.Length == 0)
            {
                Picasso.With(this)
    .Load("https://scontent-lht6-1.xx.fbcdn.net/v/t31.0-8/1655427_10152860293171477_8238146892995446072_o.jpg?oh=97ed40cc6ef5923016276198862681e4&oe=5A91F48D")
    .Into(BookImage);
            }
            else
            {
                Picasso.With(this)
                    .Load(BookSelected.Cover)
                    .Into(BookImage);
            }
        }
        
    }
}