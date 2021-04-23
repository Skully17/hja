using LawTechTeam.Views;
using Xamarin.Forms;

namespace LawTechTeam
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SurveyDetailPage), typeof(SurveyDetailPage));
            Routing.RegisterRoute(nameof(NewSurveyPage), typeof(NewSurveyPage));
        }

    }
}
