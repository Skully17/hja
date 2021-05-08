using LawTechTeam.Services;
using LawTechTeam.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(LoginClicked);
            RegisterCommand = new Command(RegisterClicked);
        }

        async void RegisterClicked()
        {
            App.Current.MainPage = new RegistrationPage();
        }

        async void LoginClicked()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).FirstOrDefault();

            if (myquery != null)
            {
                set_current_user(myquery.Email);
                App.Current.MainPage = new AppShell();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await Application.Current.MainPage.DisplayAlert("Error", "Incorrect email or password", "", "Ok");

                    if (result)
                        //await Navigation.PushAsync(new LoginPage());
                        App.Current.MainPage = new LoginPage();
                    else
                    {
                        App.Current.MainPage = new LoginPage();
                    }
                });
            }
        }
        void set_current_user (string email)
        {
            if (App.Current.Properties.ContainsKey("current_user"))
            {
                App.Current.Properties["current_user"] = email;
            }
            else
            {
                App.Current.Properties.Add("current_user", email);
            }
        }
    }
}
