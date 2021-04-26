using LawTechTeam.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    [QueryProperty(nameof(CaseID), nameof(CaseID))]
    public class SurveyDetailViewModel : BaseViewModel
    {
        private int caseID;
        private string station;
        private string date;
        private string time;

        public Survey Survey { get; set; }

        public Command DeleteSurveyCommand { get; }

        public SurveyDetailViewModel()
        {
            Title = station;

            DeleteSurveyCommand = new Command(OnDeleteSurvey);
        }

        public string Station
        {
            get => station;
            set => SetProperty(ref station, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }

        public int CaseID
        {
            get
            {
                return caseID;
            }
            set
            {
                caseID = value;
                LoadSurveyId(value);
            }
        }

        public async void OnDeleteSurvey()
        {
            try
            {
                await App.Database.DeleteSurveyAsync(Survey);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to delete survey");
            }
        }

        public async void LoadSurveyId(int surveyId)
        {
            try
            {
                Survey = await App.Database.GetSurveysAsync_ID_Asc(surveyId);
                CaseID = Survey.CaseID;
                Station = Survey.Station;
                Date = Survey.Date;
                Time = Survey.Time;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
