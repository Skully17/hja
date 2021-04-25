using LawTechTeam.Views;
using LawTechTeam.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LawTechTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RegistrationPage());
            await Shell.Current.GoToAsync("//RegistrationPage");
        }

        async void Handle_Clicked_1(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if(myquery!=null)
            {
                App.Current.MainPage = new NavigationPage(new ReportsPage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed User Name and Password", "Yes", "Cancel");

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