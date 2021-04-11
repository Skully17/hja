using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public ReportsViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}