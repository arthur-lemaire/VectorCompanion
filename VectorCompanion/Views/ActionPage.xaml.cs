using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using VectorCompanion.Models;
using VectorCompanion.Services;
using Xamarin.Forms;

namespace VectorCompanion.Views
{
    public partial class ActionPage : ContentPage
    {
        public ActionPage()
        {
            InitializeComponent();
        }
        void OnButtonSayTextClicked(object senderObject, EventArgs e)
        {
            try
            {
                
                VectorApiService vectorApiService = new VectorApiService();
                var currentVector = (Vector)Application.Current.Properties["currentVector"];
                vectorApiService.SendTextToSay(currentVector, txtTextToSay.Text);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
