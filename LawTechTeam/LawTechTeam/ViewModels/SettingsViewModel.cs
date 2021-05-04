using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;

namespace LawTechTeam.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LogOut { get; }
        private string firstname;

        public SettingsViewModel()
        {
            Title = "Settings";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            LogOut = new Command(LogOutClicked);
        }

        public string FirstName
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        //public async void LoadUserId(int userId)
        //{
        //    SQLiteAsyncConnection database;

        //    database = new SQLiteAsyncConnection(dbPath);
        //    database.CreateTableAsync<RegUserTable>().Wait();

        //    try
        //    {
        //        User = await App.Database.;
        //        FirstName = User.FirstName;
        //    }
        //    catch (Exception)
        //    {
        //        Debug.WriteLine("Failed to Load Account");
        //    }
        //}

        public ICommand OpenWebCommand { get; }

        async void LogOutClicked()
        {
            App.Current.MainPage = new Views.LoginPage();
        }
    }
}