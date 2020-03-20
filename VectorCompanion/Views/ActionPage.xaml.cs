using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace VectorCompanion.Views
{
    public partial class ActionPage : ContentPage
    {
        public ActionPage()
        {
            InitializeComponent();
        }
        async void OnButtonSayHelloClicked(object senderObject, EventArgs e)
        {
            try
            {
                Debug.WriteLine("ça passe");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000");
                var textToSay = txtTextToSay.Text;
                await client.GetAsync("/vector/Z5E2/message/"+textToSay);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
