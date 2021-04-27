using LawTechTeam.Views;
using System;
using LawTechTeam.Enum;
using Xamarin.Forms;

namespace LawTechTeam.ViewModels
{
    public class NewSurveyViewModel : BaseViewModel
    {
        private string _station;
        private string _detaineeAge;
        private string _detaineeRace;
        private int _detaineeMaleGender;
        private int _detaineeFemaleGender;
        private int _detaineeOtherGender;
        private int _detaineePfntsGender;
        private string _detaineeReligion;
        private int _hasExperiencedRacism;
        private int _hasExperiencedRacismInCustody;
        private int _hasHadInjuryInCustody;
        private int _sustainedInjuries;
        private string _racismExperience;
        private string _racismExperiencedInTimeAtStation;
        private string _district;
        private string _committedOffences;
        private string _injuryDetail;

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
            //    && !String.IsNullOrEmpty(HasExperiencedRacism)
            //    && !String.IsNullOrEmpty(RacismExperience)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStation)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStationExample);
            return true;
        }

        public string Station
        {
            get => _station;
            set => SetProperty(ref _station, value);
        }

        public string DetaineeAge
        {
            get => _detaineeAge;
            set => SetProperty(ref _detaineeAge, value);
        }

        public string DetaineeReligion
        {
            get => _detaineeReligion;
            set => SetProperty(ref _detaineeReligion, value);
        }

        public int Male
        {
            get => _detaineeMaleGender;
            set => SetProperty(ref _detaineeMaleGender, value);
        }

        public int Female
        {
            get => _detaineeFemaleGender;
            set => SetProperty(ref _detaineeFemaleGender, value);
        }

        public int Other
        {
            get => _detaineeOtherGender;
            set => SetProperty(ref _detaineeOtherGender, value);
        }

        public int PreferNotToSay
        {
            get => _detaineePfntsGender;
            set => SetProperty(ref _detaineePfntsGender, value);
        }

        public int YesHasExperiencedRacism
        {
            get => _hasExperiencedRacism;
            set => SetProperty(ref _hasExperiencedRacism, value);
        }

        public int NoHasExperiencedRacism
        {
            get => _hasExperiencedRacism;
            set => SetProperty(ref _hasExperiencedRacism, value);
        }

        public int YesHasExperiencedRacismInCustody
        {
            get => _hasExperiencedRacismInCustody;
            set => SetProperty(ref _hasExperiencedRacismInCustody, value);
        }

        public int NoHasExperiencedRacismInCustody
        {
            get => _hasExperiencedRacismInCustody;
            set => SetProperty(ref _hasExperiencedRacismInCustody, value);
        }

        public int YesSustainedInjuries
        {
            get => _hasHadInjuryInCustody;
            set => SetProperty(ref _hasHadInjuryInCustody, value);
        }

        public int NoSustainedInjuries
        {
            get => _hasHadInjuryInCustody;
            set => SetProperty(ref _hasHadInjuryInCustody, value);
        }

        public string District
        {
            get => _district;
            set => SetProperty(ref _district, value);
        }

        public string CommittedOffence
        {
            get => _committedOffences;
            set => SetProperty(ref _committedOffences, value);
        }

        public string RacismExperience
        {
            get => _racismExperience;
            set => SetProperty(ref _racismExperience, value);
        }

        public string RacismExperiencedAtStation
        {
            get => _racismExperiencedInTimeAtStation;
            set => SetProperty(ref _racismExperiencedInTimeAtStation, value);
        }

        public string DetaineeEthnicity
        {
            get => _detaineeRace;
            set => SetProperty(ref _detaineeRace, value);
        }

        public string SustainedInjuries
        {
            get => _injuryDetail;
            set => SetProperty(ref _injuryDetail, value);
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
                Station = "London Police Station",
                Date = $"{DateTime.Now:dd/MM/yyyy}",
                Time = $"{DateTime.Now:HH:mm}",
                DetaineeAge = DetaineeAge,
                Race = DetaineeEthnicity,
                RacismExperiencedAtStation = RacismExperiencedAtStation,
                RacismExperiencedExample = RacismExperience,
                Gender = Male > 0 ? GenderEnum.Male : Female > 0 ? GenderEnum.Female : Other > 0 ? GenderEnum.Other : PreferNotToSay > 0 ? GenderEnum.PreferNotToSay : GenderEnum.Default,
                HasExperiencedRacismInPast = YesHasExperiencedRacism > 0 ? YesNoEnum.Yes : NoHasExperiencedRacism > 0 ? YesNoEnum.No : YesNoEnum.Default,
                HasExperiencedRacismInCustody = YesHasExperiencedRacismInCustody > 0 ? YesNoEnum.Yes : NoHasExperiencedRacismInCustody > 0 ? YesNoEnum.No : YesNoEnum.Default,
                SustainedInjuries = YesSustainedInjuries > 0 ? YesNoEnum.Yes : NoSustainedInjuries > 0 ? YesNoEnum.No : YesNoEnum.Default,
                InjuryDetail = SustainedInjuries
            };

            await App.Database.SaveSurveyAsync(newSurvey);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
