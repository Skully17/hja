using LawTechTeam.Views;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class SurveysViewModel : BaseViewModel
    {
        private Survey _selectedSurvey;

        // public ObservableCollection<Survey> Surveys { get; }
        public Command LoadSurveysCommand { get; }
        public Command AddSurveyCommand { get; }
        public Command<Survey> SurveyTapped { get; }

        public SurveysViewModel()
        {
            Title = "Browse";
            //Surveys = new ObservableCollection<Survey>();
            LoadSurveysCommand = new Command(OnAppearing);

            SurveyTapped = new Command<Survey>(OnSurveySelected);

            AddSurveyCommand = new Command(OnAddSurvey);
        }


        public void OnAppearing()
        {
            IsBusy = true;
            SelectedSurvey = null;
        }

        public Survey SelectedSurvey
        {
            get => _selectedSurvey;
            set
            {
                SetProperty(ref _selectedSurvey, value);
                OnSurveySelected(value);
            }
        }

        private async void OnAddSurvey(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewSurveyPage));
        }

        async void OnSurveySelected(Survey survey)
        {
            if (survey == null)
                return;

            // This will push the SurveyDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(SurveyDetailPage)}?{nameof(SurveyDetailViewModel.CaseID)}={survey.CaseId}");
        }


    }
}