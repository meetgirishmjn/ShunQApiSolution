using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using xApp.Views;
using Java.Interop;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xApp.Models;
using xApp.ViewModels;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(xApp.Droid.Custom.ExtendedWebViewRenderer))]
namespace xApp.Droid.Custom
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        const string JavascriptFunction = "function jsWebViewCallback(data){jsBridge.invokeAction(data);}";
        Context _context;

        public ExtendedWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);


            var webView = new Android.Webkit.WebView(_context);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webView.Settings.SetSupportMultipleWindows(true);
     //       webView.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
            if (Control == null)
            {
                //var webView = new Android.Webkit.WebView(_context);
                //webView.Settings.JavaScriptEnabled = true;
                //webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
                //webView.Settings.SetSupportMultipleWindows(true);
                //webView.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                //SetNativeControl(webView);

            }
            else
            {
                Control.SetWebChromeClient(new CustomWebChromeClient());
            }

            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");

            }
            if (e.NewElement != null)
            {
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                // Control.LoadUrl("file:///android_asset/Content/"+Element.Id);
            }
        }

         
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            Parent.RequestDisallowInterceptTouchEvent(true);
            return base.DispatchTouchEvent(e);
        }

    }

    public class JavascriptWebViewClient : WebViewClient
    {
        string _javascript;
        public JavascriptWebViewClient(string javascript)
        {
            _javascript = javascript;
        }
        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }


    }
    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<ExtendedWebViewRenderer> hybridWebViewRenderer;
        public JSBridge(ExtendedWebViewRenderer hybridRenderer)
        {
            hybridWebViewRenderer = new WeakReference<ExtendedWebViewRenderer>(hybridRenderer);
        }
        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            try
            {
                //var evt = JsonConvert.DeserializeObject<EventMessage>(data);
                //if (evt.EventName == "onScanAdd")
                //{
                //    try
                //    {
                //        var storeId = (int)evt.EventData.GetValue("storeId");

                //        scanPage = new ScanPageNew(storeId, "Scan Item To Add", true);
                //        scanPage.OnScanResult += ScanPage_OnScanResult;
                //        App.Current.MainPage = new NavigationPage(scanPage);
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
                //else if (evt.EventName == "onScanRemove")
                //{
                //    try
                //    {
                //        var storeId = (int)evt.EventData.GetValue("storeId");

                //        scanPage = new ScanPageNew(storeId, "Scan Item To Remove", false);
                //        scanPage.OnScanResult += ScanPage_OnScanResult;
                //        App.Current.MainPage = new NavigationPage(scanPage);
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
                //else if (evt.EventName == "onNavigationEnd")
                //{
                //    var url = (string)evt.EventData.GetValue("url");
                //    AppConfig.CurrentRoute = url;
                //}

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CustomWebChromeClient : WebChromeClient
    {
        public override void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
        {
            callback.Invoke(origin, true, false);
        }
    }
}