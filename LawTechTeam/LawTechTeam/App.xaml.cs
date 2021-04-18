using LawTechTeam.Services;
using LawTechTeam.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            MainPage = new LoginPage();
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
