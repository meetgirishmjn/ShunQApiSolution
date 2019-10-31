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
using xApp.Services;
using static Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(xApp.Droid.Custom.Toastr))]
namespace xApp.Droid.Custom
{
    public class Toastr : IToastr
    {
        public string GetDeviceId()
        {
            var id = Android.OS.Build.Serial;
            if (string.IsNullOrWhiteSpace(id) || id == Build.Unknown || id == "0")
            {
                try
                {
                    var context = Android.App.Application.Context;
                    id = Secure.GetString(context.ContentResolver, Secure.AndroidId);
                }
                catch (Exception ex)
                {
                    Android.Util.Log.Warn("DeviceInfo", "Unable to get id: " + ex.ToString());
                }
            }

            return id;
        }

        public void ShowWarning(string message)
        {
            var toast= Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast.View?.SetBackgroundColor(Android.Graphics.Color.Rgb(74, 202, 255));
            toast.Show();
        }

        public void ShowError(string message)
        {
            var toast = Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast.View?.SetBackgroundColor(Android.Graphics.Color.Rgb(128, 0, 0));
            toast.Show();
        }

        public void ShowInfo(string message)
        {
            var toast = Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast.View?.SetBackgroundColor(Android.Graphics.Color.Rgb(49, 112, 143));
            toast.Show();
        }
    }
}