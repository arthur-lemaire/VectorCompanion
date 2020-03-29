using System;
using System.Collections.Generic;
using System.Diagnostics;
using VectorCompanion.Models;
using VectorCompanion.Services;
using Xamarin.Forms;

namespace VectorCompanion.Views
{
    public partial class MovementPage : ContentPage
    {
        public MovementPage()
        {
            InitializeComponent();
        }
        void OnButtonPressed(object senderObject, EventArgs e)
        {
            try
            {
                var pressedButton = (Button)senderObject;
                VectorApiService serviceVector = new VectorApiService();
                var currentVector = (Vector)Application.Current.Properties["currentVector"];
                serviceVector.Movement(currentVector, 50, pressedButton.Text.ToLower());
            }catch(Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
