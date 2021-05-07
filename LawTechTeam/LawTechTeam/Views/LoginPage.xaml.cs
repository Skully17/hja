using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LawTechTeam.ViewModels;

namespace LawTechTeam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}