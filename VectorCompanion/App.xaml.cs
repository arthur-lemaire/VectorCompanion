using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VectorCompanion.Services;
using VectorCompanion.Views;
using VectorCompanion.Storage;
using VectorCompanion.Models;

namespace VectorCompanion
{
    public partial class App : Application
    {
        static VectorDatabase database;
        static Vector Vector;

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static VectorDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new VectorDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
