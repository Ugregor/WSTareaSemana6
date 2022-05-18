using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSClase6.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(mensajeAD))]
namespace WSClase6.Droid
{
    class mensajeAD : Mensaje
    {
        public void alertShort(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}