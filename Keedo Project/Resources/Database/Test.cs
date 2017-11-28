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
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Keedo_Project.Resources.Database
{
    class Test
    {

        //Create our client and table variables
        public MobileServiceClient Client { get; set; }
        IMobileServiceTable<Books> bookTable;

        //Creating the connection for the database
        public void CreateConnection(Context X)
        {
            try
            {
                //Point our client towards the backend
                Client = new MobileServiceClient("http://keedoapp.azurewebsites.net");

                //Get the table model from the backend.
                bookTable = Client.GetTable<Books>();

            }
            catch
            {
                var alert = new AlertDialog.Builder(X);
                alert.SetMessage("ohno!");
                alert.SetNeutralButton("Okay", delegate { });
                alert.Show();
            }
        }

        public async Task AddBook(Context X)
        {
            try
            {
                CreateConnection(X);

                var newBook = new Books
                {
                    BookName = "Name",
                    BookPrice = "Nameo"
                };

                await bookTable.InsertAsync(newBook);
            }
            catch (Exception ex)
            {
                var alert = new AlertDialog.Builder(X);
                alert.SetMessage("Uhoh!" + ex);
                alert.SetNeutralButton("Okay", delegate { });
                alert.Show();

            }
        }

    }
}