using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App88
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new App88.MainPage();

            Crashes.ShouldProcessErrorReport = (report) =>
            {
                return true; // return true if the crash report should be processed, otherwise false.
            };


            ////Crashes.GetErrorAttachment = (report) =>
            ////{
            ////    return null;
            ////    // return your own created ErrorAttachment object
            ////};

            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                return true; // Return true if the SDK should await user confirmation, otherwise false.
            };

            MobileCenter.Start(typeof(Analytics), typeof(Crashes));


            Crashes.SentErrorReport += Crashes_SentErrorReport;
            Crashes.SendingErrorReport += Crashes_SendingErrorReport;


            MobileCenter.LogLevel = LogLevel.Verbose;

            Crashes.Enabled = true;
           // var b = Crashes.HasCrashedInLastSession;

           // Debug.WriteLine(b);

           
            //Crashes.NotifyUserConfirmation(UserConfirmation.Send);

        }

        private void Crashes_SendingErrorReport(object sender, SendingErrorReportEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Crashes_SentErrorReport(object sender, SentErrorReportEventArgs e)
        {
          //  throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
