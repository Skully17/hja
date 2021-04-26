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

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Handle_Clicked_1);
            RegisterCommand = new Command(Handle_Clicked);
        }

        async void Handle_Clicked()
        {
            //await Navigation.PushAsync(new RegistrationPage());
            App.Current.MainPage = new RegistrationPage();
        }

        async void Handle_Clicked_1()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(Username) && u.Password.Equals(Password)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new AppShell();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await Application.Current.MainPage.DisplayAlert("Error", "Failed User Name and Password", "Yes", "Cancel");

                    if (result)
                        //await Navigation.PushAsync(new LoginPage());
                        await Shell.Current.GoToAsync("//LoginPage");
                    else
                    {
                        await Shell.Current.GoToAsync("//LoginPage");
                    }
                });
                //LOGOUT BUTTON WILL TAKE YOU BACK TO LOGIN PAGE NOTHING MORE NOTHING LESS
            }
        }
    }
}
