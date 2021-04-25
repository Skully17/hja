using LawTechTeam.Models;
using LawTechTeam.ViewModels;
using System;
using System.Collections.Generic;
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
            this.BindingContext = new LoginViewModel();
            Init();
        }
        void Init()
        {
            BackgroundColor = constants.BackgroundColor;
            Lbl_Username.TextColor = constants.MainTextColor;
            Lbl_Password.TextColor = constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = constants.LoginIconHeight;


            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }




        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInInformation())
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//ReportsPage");
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct", "Okay");
            }
        }
    }
}