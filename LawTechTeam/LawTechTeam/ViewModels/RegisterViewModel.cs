using LawTechTeam.Services;
using LawTechTeam.Views;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private string admin;
        private string firstname;
        private string lastname;
        private string rep_pin;
        private string super_pin;
        public Command CancelCommand { get; }
        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            CancelCommand = new Command(CancelClicked);
            RegisterCommand = new Command(RegisterClicked);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
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
        public string RepPIN
        {
            get => rep_pin;
            set => SetProperty(ref rep_pin, value);
        }
        public string SuperPIN
        {
            get => super_pin;
            set => SetProperty(ref super_pin, value);
        }

        async void RegisterClicked()
        {
            if (Email == null || Password == null || Admin == null || Firstname == null || Lastname == null || RepPIN == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Not all required details have been entered", "Ok");
            }

            else
            {
                var item = new RegUserTable()
                {
                    Email = Email,
                    Password = Password,
                    Admin = Admin,
                    FirstName = Firstname,
                    LastName = Lastname,
                    RepresentativePIN = RepPIN,
                    SupervisorPIN = SuperPIN
                };

                App.Database.SaveUserAsync(item);
                App.Current.MainPage = new LoginPage();
            }
        }
        async void CancelClicked()
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}
