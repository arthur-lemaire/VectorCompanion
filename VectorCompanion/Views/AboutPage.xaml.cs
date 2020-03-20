using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using VectorCompanion.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VectorCompanion.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            SetListVector();
            
            //SetListVector();
        }
        public async void OnAddVector(object sender, EventArgs e)
        {
            var newVector = new Vector() { Name = txtAddVector.Text };
            await App.Database.SaveItemAsync(newVector);
            SetListVector();
        }
        
        public async void OnRemoveVector(object sender, EventArgs e)
        {
            await App.Database.DeleteItemAsync((Vector)listVector.SelectedItem);
            SetListVector();
        }
        public async void SetListVector()
        {
            listVector.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}