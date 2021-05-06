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
        private string _detaineeEthnicity;
        private int _detaineeMaleGender;
        private int _detaineeFemaleGender;
        private int _detaineeOtherGender;
        private int _detaineePfntsGender;
        private string _detaineeReligion;
        private int _hasExperiencedRacism;
        private int _hasExperiencedRacismInCustody;
        private int _hasHadInjuryInCustody;
        private int _hasBeenStoppedAndSearched;
        private string _racismExperience;
        private string _racismExperiencedInTimeAtStation;
        private string _district;
        private string _committedOffences;
        private string _injuryDetail;
        private string _stoppedAndSearchedReason;
        private bool _drugPossession;
        private bool _weaponPossession;
        private bool _minorAssault;
        private bool _seriousAssault;
        private bool _sexualOffences;
        private bool _publicOrderOffences;
        private bool _theftOrRobbery;
        private bool _fraud;
        private bool _driving;
        private bool _otheroffence;
        private int _noHasHadInjuryInCustody;
        private int _noHasExperiencedRacismInCustody;
        private int _noHasExperiencedRacism;
        private int _noHasBeenStoppedAndSearched;

        public NewSurveyViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            //return !String.IsNullOrWhiteSpace(DetaineeAge)
            //    && detaineeEthnicity > 0
            //    && !String.IsNullOrEmpty(HasExperiencedRacism)
            //    && !String.IsNullOrEmpty(RacismExperience)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStation)
            //    && !String.IsNullOrEmpty(RacismExperiencedAtStationExample);
            return true;
        }

        public bool DrugPossession
        {
            get => _drugPossession;
            set => SetProperty(ref _drugPossession, value);
        }

        public bool WeaponPossession
        {
            get => _weaponPossession;
            set => SetProperty(ref _weaponPossession, value);
        }

        public bool MinorAssault
        {
            get => _minorAssault;
            set => SetProperty(ref _minorAssault, value);
        }

        public bool SeriousAssault
        {
            get => _seriousAssault;
            set => SetProperty(ref _seriousAssault, value);
        }

        public bool SexualOffences
        {
            get => _sexualOffences;
            set => SetProperty(ref _sexualOffences, value);
        }

        public bool TheftOrRobbery
        {
            get => _theftOrRobbery;
            set => SetProperty(ref _theftOrRobbery, value);
        }

        public bool Fraud
        {
            get => _fraud;
            set => SetProperty(ref _fraud, value);
        }

        public bool PublicOrderOffences
        {
            get => _publicOrderOffences;
            set => SetProperty(ref _publicOrderOffences, value);
        }

        public bool Driving
        {
            get => _driving;
            set => SetProperty(ref _driving, value);
        }

        public bool OtherOffence
        {
            get => _otheroffence;
            set => SetProperty(ref _otheroffence, value);
        }

        public string StoppedAndSearchedReason
        {
            get => _stoppedAndSearchedReason;
            set => SetProperty(ref _stoppedAndSearchedReason, value);
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

        public int YesStoppedAndSearched
        {
            get => _hasBeenStoppedAndSearched;
            set => SetProperty(ref _hasBeenStoppedAndSearched, value);
        }

        public int NoStoppedAndSearched
        {
            get => _noHasBeenStoppedAndSearched;
            set => SetProperty(ref _noHasBeenStoppedAndSearched, value);
        }

        public int YesHasExperiencedRacism
        {
            get => _hasExperiencedRacism;
            set => SetProperty(ref _hasExperiencedRacism, value);
        }

        public int NoHasExperiencedRacism
        {
            get => _noHasExperiencedRacism;
            set => SetProperty(ref _noHasExperiencedRacism, value);
        }

        public int YesHasExperiencedRacismInCustody
        {
            get => _hasExperiencedRacismInCustody;
            set => SetProperty(ref _hasExperiencedRacismInCustody, value);
        }

        public int NoHasExperiencedRacismInCustody
        {
            get => _noHasExperiencedRacismInCustody;
            set => SetProperty(ref _noHasExperiencedRacismInCustody, value);
        }

        public int YesSustainedInjuries
        {
            get => _hasHadInjuryInCustody;
            set => SetProperty(ref _hasHadInjuryInCustody, value);
        }

        public int NoSustainedInjuries
        {
            get => _noHasHadInjuryInCustody;
            set => SetProperty(ref _noHasHadInjuryInCustody, value);
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
            get => _detaineeEthnicity;
            set => SetProperty(ref _detaineeEthnicity, value);
        }

        public string SustainedInjuries
        {
            get => _injuryDetail;
            set => SetProperty(ref _injuryDetail, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnSave()
        {
            var result = await Application.Current.MainPage.DisplayPromptAsync("Police Station", "What police station does this survey relate to?", "Save", "Cancel");
            
            if (result == "")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a station name", "Ok");
            }

            else
            {
                Survey newSurvey = new Survey
                {
                    Station = result,
                    Date = $"{DateTime.Now:dd/MM/yyyy}",
                    Time = $"{DateTime.Now:HH:mm}",
                    DetaineeAge = DetaineeAge,
                    DetaineeReligion = DetaineeReligion,
                    Race = DetaineeEthnicity,
                    District = District,
                    RacismExperiencedAtStation = RacismExperiencedAtStation,
                    RacismExperiencedExample = RacismExperience,
                    Gender = Male > 0 ? GenderEnum.Male : Female > 0 ? GenderEnum.Female : Other > 0 ? GenderEnum.Other : PreferNotToSay > 0 ? GenderEnum.PreferNotToSay : GenderEnum.Unanswered,
                    HasExperiencedRacismInPast = YesHasExperiencedRacism > 0 ? YesNoEnum.Yes : NoHasExperiencedRacism > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                    HasExperiencedRacismInCustody = YesHasExperiencedRacismInCustody > 0 ? YesNoEnum.Yes : NoHasExperiencedRacismInCustody > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                    SustainedInjuries = YesSustainedInjuries > 0 ? YesNoEnum.Yes : NoSustainedInjuries > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                    InjuryDetail = SustainedInjuries,
                    WasStoppedAndSearched = YesStoppedAndSearched > 0 ? YesNoEnum.Yes : NoStoppedAndSearched > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                    StoppedAndSearchedReason = StoppedAndSearchedReason,
                    DrugOffence = DrugPossession,
                    Fraud = Fraud,
                    MinorAssaultOffence = MinorAssault,
                    Driving = Driving,
                    PublicOrderOffence = PublicOrderOffences,
                    SeriousAssaultOffence = SeriousAssault,
                    TheftOrRobberyOffence = TheftOrRobbery,
                    SexualOffence = SexualOffences,
                    WeaponOffence = WeaponPossession,
                    OtherOffence = OtherOffence,
                    CommittedOffence = CommittedOffence
                };

                await App.Database.SaveSurveyAsync(newSurvey);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
