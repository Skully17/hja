using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using LawTechTeam.Services;

namespace LawTechTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            if (EntryEmail.Text == null || EntryUserPassword.Text == null || EntryUserAdmin.Text == null || EntryFirstName.Text == null || EntryLastName.Text == null || EntryRepPin.Text == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Not all required details have been entered", "Ok");
            }

            else
            { 
                var item = new RegUserTable()
                {
                    Email = EntryEmail.Text,
                    Password = EntryUserPassword.Text,
                    Admin = EntryUserAdmin.Text,
                    FirstName = EntryFirstName.Text,
                    LastName = EntryLastName.Text,
                    RepresentativePIN = EntryRepPin.Text,
                    SupervisorPIN = EntrySupPin.Text
                };

                db.Insert(item);
                App.Current.MainPage = new LoginPage();
            }

            
        }

        void CancelClicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}