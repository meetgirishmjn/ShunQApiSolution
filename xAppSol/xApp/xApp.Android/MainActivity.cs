using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Plugin.FacebookClient;
using Android.Content;

namespace xApp.Droid
{
    [Activity(Label = "ShunQ", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FacebookClientManager.Initialize(this);
            CachedImageRenderer.InitImageViewHandler();
            Syncfusion.XForms.Android.PopupLayout.SfPopupLayoutRenderer.Init();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
                FacebookClientManager.OnActivityResult(requestCode, resultCode, data);
        }
        protected override void OnDestroy()
        {
            try
            {
                base.OnDestroy();
            }
            catch(Exception ex)
            {
            
            }
          
        }
    }
}