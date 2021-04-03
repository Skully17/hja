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
        private string surveyId;
        private string detaineeID;
        private string station;
        private string date;
        public string Id { get; set; }

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

        public string SurveyId
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

        public async void LoadSurveyId(string surveyId)
        {
            try
            {
                var survey = await DataStore.GetSurveyAsync(surveyId);
                Id = survey.Id;
                DetaineeID = survey.DetaineeID;
                Station = survey.Station;
                Date = survey.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
