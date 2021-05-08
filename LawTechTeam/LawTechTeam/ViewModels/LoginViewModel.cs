using LawTechTeam.Views;
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
            var user = await App.Database.ValidateLogin(Email, Password);
            if (user != null)
            {
                SetCurrentUser(user.UserId);
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
        void SetCurrentUser (int user_id)
        {
            if (App.Current.Properties.ContainsKey("current_user"))
            {
                App.Current.Properties["current_user"] = user_id;
            }
            else
            {
                App.Current.Properties.Add("current_user", user_id);
            }
        }
    }
}
