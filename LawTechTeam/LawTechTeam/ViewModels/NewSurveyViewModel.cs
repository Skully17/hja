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
        private string DetaineeID;
        private string Station;
        private string Date;

        public NewSurveyViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(DetaineeID)
                && !String.IsNullOrWhiteSpace(Station)
                && !String.IsNullOrWhiteSpace(Date);
        }

        public string detaineeID
        {
            get => DetaineeID;
            set => SetProperty(ref DetaineeID, value);
        }

        public string station
        {
            get => Station;
            set => SetProperty(ref Station, value);
        }
        public string date
        {
            get => Date;
            set => SetProperty(ref Date, value);
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
                Id = Guid.NewGuid().ToString(),
                DetaineeID = DetaineeID,
                Station = Station,
                Date = Date
            };

            await DataStore.AddSurveyAsync(newSurvey);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
