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
