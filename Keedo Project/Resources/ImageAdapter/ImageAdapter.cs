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
using Java.Lang;
using Square.Picasso;
using Keedo_Project.Resources.Datamodel;
using Android.Graphics;
using Keedo_Project.Resources.DialogControl;

namespace Keedo_Project.Resources.ImageAdapter
{
    class ImageAdapter : BaseAdapter
    {
        Context context;

        private LayoutInflater inflater;

        List<Inventory> Inventory;

        public ImageAdapter(Context c, List<Inventory> x)
        {
            context = c;
            Inventory = x;
        }

        public override int Count
        {
            get
            {
                return Inventory.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TextView txtView;
            ImageView imgView;

            if (inflater == null)
            {
                inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            }

            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.Model, parent, false);
                txtView = convertView.FindViewById<TextView>(Resource.Id.TestText);
                imgView = convertView.FindViewById<ImageView>(Resource.Id.testImage);
            }
            else
            {
                txtView = convertView.FindViewById<TextView>(Resource.Id.TestText);
                imgView = convertView.FindViewById<ImageView>(Resource.Id.testImage);
            }
                //Binding data

                txtView.Text = Inventory[position].Title;
            if (Inventory[position].Cover.Length > 0)
            {
                Picasso.With(context)
                       .Load(Inventory[position].Cover)
                       .Into(imgView);
            }
            else
            {
                Picasso.With(context)
               .Load("http://blog.improveeze.com/wp-content/uploads/2011/10/logo_keedo.png")
               .Into(imgView);
            }

                return convertView;

            }

    }
}
