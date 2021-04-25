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

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Handle_Clicked_1);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(ReportsPage)}");
        }
        async void Handle_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RegistrationPage());
            await Shell.Current.GoToAsync("//RegistrationPage");
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
