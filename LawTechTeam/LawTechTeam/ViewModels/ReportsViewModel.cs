using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public ReportsViewModel()
        {
            Title = "Reports";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}