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
        public Command SaveButton { get; }
        private int user_id;
        private string email;
        private string firstname;
        private string lastname;
        private string password;
        private string admin;
        private string rep_pin;
        private string supervisor_pin;

        public SettingsViewModel()
        {
            Title = "Settings";
            LogOut = new Command(LogOutClicked);
            UserID = (int)App.Current.Properties["current_user"];
            GetUserDetails();
            SaveButton = new Command(OnSaveDetails);
        }
        public int UserID
        {
            get => user_id;
            set => SetProperty(ref user_id, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Firstname
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string Lastname
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string Admin
        {
            get => admin;
            set => SetProperty(ref admin, value);
        }
        public string RepPIN
        {
            get => rep_pin;
            set => SetProperty(ref rep_pin, value);
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
        public async void GetUserDetails()
        {
            var user = await App.Database.GetUser(UserID);
            Email = user.Email;
            Firstname = user.FirstName;
            Lastname = user.LastName;
            Password = user.Password;
            Admin = user.Admin;
            RepPIN = user.RepresentativePIN;
            SuperPIN = user.SupervisorPIN;
        }
        public async void OnSaveDetails()
        {
            var item = new RegUserTable()
            {
                UserId = UserID,
                Email = Email,
                Password = Password,
                Admin = Admin,
                FirstName = Firstname,
                LastName = Lastname,
                RepresentativePIN = RepPIN,
                SupervisorPIN = SuperPIN
            };
            App.Database.SaveUserAsync(item);
        }
    }
}