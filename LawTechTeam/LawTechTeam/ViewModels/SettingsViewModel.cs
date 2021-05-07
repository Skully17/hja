using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using LawTechTeam.Services;

namespace LawTechTeam.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LogOut { get; }
        private string email;
        private string firstname;
        private string lastname;
        private string password;
        private string pin;
        private string supervisor_pin;

        public SettingsViewModel()
        {
            Title = "Settings";
            LogOut = new Command(LogOutClicked);
            Email = App.Current.Properties["current_user"] as string;
        }
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                SetUserDetails();
            }
        }
        public string FirstName
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string LastName
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string PIN
        {
            get => pin;
            set => SetProperty(ref pin, value);
        }
        public string SuperPIN
        {
            get => supervisor_pin;
            set => SetProperty(ref supervisor_pin, value);
        }
        public Task<RegUserTable> GetUserByEmail(string email)
        {
            SQLiteAsyncConnection database;

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");

            database = new SQLiteAsyncConnection(dbPath);
            return database.Table<RegUserTable>().Where(i => i.Email == email).FirstOrDefaultAsync();
        }

        async void LogOutClicked()
        {
            App.Current.MainPage = new Views.LoginPage();
        }
        public async void SetUserDetails()
        {
            var user = await GetUserByEmail(email);
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = new string('*', user.Password.Length);
            PIN = user.RepresentativePIN;
            SuperPIN = user.SupervisorPIN;
        }
    }
}