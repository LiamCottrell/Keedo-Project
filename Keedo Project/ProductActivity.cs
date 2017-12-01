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

            PopulateBook();

        }

        async void PopulateBook()
        {
            var value = await Inventory.SearchModule();

            BookTitle.Text = value[0].Title;
            BookPrice.Text = value[0].Price;
            BookDescription.Text = value[0].Description;
            Author.Text = value[0].Authors;

            Picasso.With(this)
                .Load(value[0].Cover)
                .Into(BookImage);
        }
        
    }
}