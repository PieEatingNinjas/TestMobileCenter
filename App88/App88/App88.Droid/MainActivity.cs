using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Crashes;

namespace App88.Droid
{
    [Activity(Label = "App88", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            MobileCenter.Configure("0b3c1552-849b-4494-9b5c-be174697de41");

            LoadApplication(new App());

            //Crashes.ShouldProcessErrorReport = (report) =>
            //{
            //    return true; // return true if the crash report should be processed, otherwise false.
            //};


            ////Crashes.GetErrorAttachment = (report) =>
            ////{
            ////    return null;
            ////    // return your own created ErrorAttachment object
            ////};

            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                return true; // Return true if the SDK should await user confirmation, otherwise false.
            };
        }
    }
}

