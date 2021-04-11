using LawTechTeam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(station)
                && !String.IsNullOrWhiteSpace(date);
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
            Survey newSurvey = new Survey()
            {
                Station = Station,
                Date = Date
            };

            await App.Database.SaveSurveyAsync(newSurvey);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
