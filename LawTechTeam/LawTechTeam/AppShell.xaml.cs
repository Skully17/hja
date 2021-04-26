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
            Routing.RegisterRoute(nameof(Graph1Page), typeof(Graph1Page));
            Routing.RegisterRoute(nameof(Graph2Page), typeof(Graph2Page));
            Routing.RegisterRoute(nameof(Graph3Page), typeof(Graph3Page));
            Routing.RegisterRoute(nameof(Graph4Page), typeof(Graph4Page));
        }

    }
}
