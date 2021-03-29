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
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                Text = survey.Text;
                Description = survey.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
