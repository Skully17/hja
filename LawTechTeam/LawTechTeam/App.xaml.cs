using LawTechTeam.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LawTechTeam.Views;

namespace LawTechTeam
{
    public partial class App : Application
    {
        static SurveyDatabase database;

        public static SurveyDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SurveyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cases.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            var isLogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLogged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new AppShell();
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
