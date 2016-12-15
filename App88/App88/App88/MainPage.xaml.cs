using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App88
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btn.Clicked += Btn_Clicked;
            btn2.Clicked += Btn2_Clicked;
            btnError.Clicked += BtnError_Clicked;
            btnError.IsEnabled = false;
            Crashes.SendingErrorReport += Crashes_SendingErrorReport;
        }

        private void Crashes_SendingErrorReport(object sender, SendingErrorReportEventArgs e)
        {
          //  throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Crashes.HasCrashedInLastSession)
            {
                btnError.IsEnabled = true;
                lblCrash.Text = Crashes.HasCrashedInLastSession ? "App did crash previously!!" : "everything OK!!";
            }
        }

        private void BtnError_Clicked(object sender, EventArgs e)
        {
            Crashes.NotifyUserConfirmation(UserConfirmation.Send);
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash();
           // throw new Exception();
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Video clicked", new Dictionary<string, string> { { "Category", "Music" }, { "FileName", "favorite2.avi" } });
        }
    }
}
