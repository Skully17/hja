using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using LawTechTeam.Views;

namespace LawTechTeam.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public Command<string> GraphClicked { get; }
        public ReportsViewModel()
        {
            Title = "Reports Home";

            GraphClicked = new Command<string>(on_button_press);
        }

        async void on_button_press(string graph_no)
        {
            if (graph_no == "1")
            {
                await Shell.Current.GoToAsync($"{nameof(Graph1Page)}");
            }
            else if (graph_no == "2")
            {
                await Shell.Current.GoToAsync($"{nameof(Graph2Page)}");
            }
            else if (graph_no == "3")
            {
                await Shell.Current.GoToAsync($"{nameof(Graph3Page)}");
            }
            else if (graph_no == "4")
            {
                await Shell.Current.GoToAsync($"{nameof(Graph4Page)}");
            }
        }
    }
}