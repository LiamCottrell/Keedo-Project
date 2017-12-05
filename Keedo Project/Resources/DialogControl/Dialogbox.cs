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

namespace Keedo_Project.Resources.DialogControl
{
    public class DialogBox
    {
         public void Popup(string x, Context context)
        {
            //Create our new dialog variable and pass the builder context for building it.
            var Alert = new AlertDialog.Builder(context);
            //Set our message as the passed in x variable
            Alert.SetMessage(x);
            //Set the neutural click button text
            Alert.SetNeutralButton("Ok", delegate { });
            //Display built alert to user.
            Alert.Show();
        }
    }

}