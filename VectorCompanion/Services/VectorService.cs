using System;

using Xamarin.Forms;

namespace VectorCompanion.Services
{
    public class VectorService : ContentPage
    {
        public VectorService()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

