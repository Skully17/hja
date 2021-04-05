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
        private string text;
        private string description;

        public Survey Survey { get; set; }

        public int Id { get; set; }

        public Command DeleteSurveyCommand { get; }

        public SurveyDetailViewModel()
        {
            Title = text;

            DeleteSurveyCommand = new Command(OnDeleteSurvey);
        }

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
                Id = Survey.id;
                Text = Survey.text;
                Description = Survey.description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}
