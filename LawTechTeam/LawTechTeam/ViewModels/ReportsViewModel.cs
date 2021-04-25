using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using LawTechTeam.Views;

namespace LawTechTeam.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public static string colour1 = "#4472c4";
        public static string colour2 = "#ed7d31";
        public static string colour3 = "#70ad47";
        public static string colour4 = "#ffc000";
        public static string colour5 = "#7030a0";
        public static string blank = "#ffffff";

        public Command<string> GraphClicked { get; }
        public ReportsViewModel()
        {
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