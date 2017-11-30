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
using System.Net.Http;

namespace Keedo_Project.Resources.Database
{
    class DatabaseConnection
    {

        //Create our client and table variables

        //HttpClient client;



        //public MobileServiceClient Client { get; set; }

        //IMobileServiceTable<InventoryTypes> Inventory;

        //public DatabaseConnection()
        //{
        //    System.Diagnostics.Debug.WriteLine("Create Connection");
        //    try
        //    {
        //        //Point our client towards the backend
        //        Client = new MobileServiceClient("http://penguinlibrary.azurewebsites.net");

        //        //Get the table model from the backend.
        //        Inventory = Client.GetTable<InventoryTypes>();
        //        System.Diagnostics.Debug.WriteLine("Try Here");

        //    }
        //    catch
        //    {
        //        System.Diagnostics.Debug.WriteLine("Failed to Create Connection");
        //    }
        //}

        //public async Task AddBook(Context X)
        //{
        //    try
        //    {
        //        CreateConnection(X);

        //        var newBook = new Books
        //        {
        //            BookName = "Name",
        //            BookPrice = "Nameo"
        //        };

        //        await bookTable.InsertAsync(newBook);
        //    }
        //    catch (Exception ex)
        //    {
        //        var alert = new AlertDialog.Builder(X);
        //        alert.SetMessage("Uhoh!" + ex);
        //        alert.SetNeutralButton("Okay", delegate { });
        //        alert.Show();

        //    }
        //}

    }
}