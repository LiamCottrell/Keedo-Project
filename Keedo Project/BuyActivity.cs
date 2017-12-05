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
using Keedo_Project.Resources.Datamodel;
using Square.Picasso;
using Keedo_Project.Resources.DialogControl;

namespace Keedo_Project
{
    [Activity(Label = "BuyActivity")]
    public class BuyActivity : Activity
    {
        private Button Purchase;
        private ImageView BookImage;
        private TextView BookTitle;
        private TextView BookAuthor;
        private TextView BookPrice;
        private EditText UserFirstName;
        private EditText UserLastName;
        private EditText UserEmail;

        private string BookSelectedUnParsed;
        private Books BookSelected;

        DialogBox Dialogopen = new DialogBox();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BuyBook);

            Purchase = (Button)FindViewById(Resource.Id.Purchase);
            BookImage = (ImageView)FindViewById(Resource.Id.BuyImage_Buy);
            BookTitle = (TextView)FindViewById(Resource.Id.BookTitle_Buy);
            BookAuthor = (TextView)FindViewById(Resource.Id.BookAuthor_Buy);
            BookPrice = (TextView)FindViewById(Resource.Id.BookPrice_Buy);
            UserFirstName = (EditText)FindViewById(Resource.Id.FirstName);
            UserLastName = (EditText)FindViewById(Resource.Id.LastName);
            UserEmail = (EditText)FindViewById(Resource.Id.Email);


            BookSelectedUnParsed = Intent.GetStringExtra("Book Selected");
            BookSelected = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(BookSelectedUnParsed);

            Purchase.Click += Purchase_Click;

            PopulatePage();
        }

        void Purchase_Click(object sender, EventArgs e)
        {
            Dialogopen.Popup("Thanks, " + UserFirstName.Text + " " + UserLastName.Text + " You have Purchased: " + BookTitle.Text, this);
        }

        void PopulatePage()
        {
            BookTitle.Text = BookSelected.title;
            BookAuthor.Text = BookSelected.authors;
            BookPrice.Text = "£";

            if (BookSelected.cover.Length == 0)
            {
                Picasso.With(this)
                .Load("https://scontent-lht6-1.xx.fbcdn.net/v/t31.0-8/1655427_10152860293171477_8238146892995446072_o.jpg?oh=97ed40cc6ef5923016276198862681e4&oe=5A91F48D")
                .Into(BookImage);
            }
            else
            {
                Picasso.With(this)
                    .Load(BookSelected.cover)
                    .Into(BookImage);
            }
        }
    }
}