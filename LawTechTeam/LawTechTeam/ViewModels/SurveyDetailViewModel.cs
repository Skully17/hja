using LawTechTeam.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    [QueryProperty(nameof(SurveyId), nameof(SurveyId))]
    public class SurveyDetailViewModel : BaseViewModel
    {
        private int surveyId;
        private string station;
        private string date;

        public Survey Survey { get; set; }

        public int Id { get; set; }

        public Command DeleteSurveyCommand { get; }

        public SurveyDetailViewModel()
        {
            Title = text;

            DeleteSurveyCommand = new Command(OnDeleteSurvey);
        }

        public string DetaineeID
        {
            get => detaineeID;
            set => SetProperty(ref detaineeID, value);
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

        public int SurveyId
        {
            get
            {
                return surveyId;
            }
            set
            {
                surveyId = value;
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
                Id = Survey.Id;
                Text = Survey.Station;
                Description = Survey.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
