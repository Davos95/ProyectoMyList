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
using mylist.Services;

[assembly: Xamarin.Forms.Dependency(typeof(mylist.Droid.Toast_Android))]
namespace mylist.Droid
{
    public class Toast_Android: Services.Toast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}