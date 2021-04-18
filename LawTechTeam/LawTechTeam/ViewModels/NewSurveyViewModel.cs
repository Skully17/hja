using LawTechTeam.Models;
using System;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class NewSurveyViewModel : BaseViewModel
    {
        private string station;
        private string date;
        private string detaineeAge;
        private int detaineeRace;
        private string isUkCitizen;
        private string hasExperiencedRacism;
        private string racismExperience;
        private string racismExperiencedInTimeAtStation;
        private string racismExperiencedAtStationExample;

        public NewSurveyViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            //return !String.IsNullOrWhiteSpace(DetaineeAge)
            //    && detaineeRace > 0
            //    && !String.IsNullOrEmpty(IsUKCitizen)
            //    && !String.IsNullOrEmpty(HasExperiencedRacism)
            //    && !String.IsNullOrEmpty(RacismExperience)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStation)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStationExample);
            return true;
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

        public string DetaineeAge
        {
            get => detaineeAge;
            set => SetProperty(ref detaineeAge, value);
        }

        public string IsUKCitizen
        {
            get => isUkCitizen;
            set => SetProperty(ref isUkCitizen, value);
        }

        public int British
        {
            get => detaineeRace;
            set => SetProperty(ref detaineeRace, value);
        }

        public int Hispanic
        {
            get => detaineeRace;
            set => SetProperty(ref detaineeRace, value);
        }

        public int Black
        {
            get => detaineeRace;
            set => SetProperty(ref detaineeRace, value);
        }

        public int Asian
        {
            get => detaineeRace;
            set => SetProperty(ref detaineeRace, value);
        }

        public string HasExperiencedRacism
        {
            get => hasExperiencedRacism;
            set => SetProperty(ref hasExperiencedRacism, value);
        }

        public string RacismExperience
        {
            get => racismExperience;
            set => SetProperty(ref racismExperience, value);
        }

        public string RacismExperiencedAtStation
        {
            get => racismExperiencedInTimeAtStation;
            set => SetProperty(ref racismExperiencedInTimeAtStation, value);
        }

        public string RacismExperiencedAtStationExample
        {
            get => racismExperiencedAtStationExample;
            set => SetProperty(ref racismExperiencedAtStationExample, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Survey newSurvey = new Survey
            {
                Station = Station,
                Date = $"{DateTime.Now:dd MMM yyyy : HH:mm}",
                DetaineeAge = DetaineeAge,
                IsUkCitizen = IsUKCitizen,
                Race = detaineeRace,
                RacismExperience = HasExperiencedRacism,
                RacismExperiencedAtStation = RacismExperiencedAtStation,
                RacismExperiencedAtStationExamples = RacismExperiencedAtStationExample,
                RacismExperiencedExample = RacismExperience
            };

            await App.Database.SaveSurveyAsync(newSurvey);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
