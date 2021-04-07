using LawTechTeam.Models;
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
                Debug.WriteLine("Failled to delete survey");
            }
        }

        public async void LoadSurveyId(int surveyId)
        {
            try
            {
                Survey = await App.Database.GetSurveyAsync(surveyId);
                CaseID = Survey.CaseID;
                Station = Survey.Station;
                Date = Survey.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
