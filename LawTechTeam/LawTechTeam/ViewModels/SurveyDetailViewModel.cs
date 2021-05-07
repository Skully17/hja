using LawTechTeam.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace LawTechTeam.ViewModels
{
    [QueryProperty(nameof(CaseID), nameof(CaseID))]
    public class SurveyDetailViewModel : BaseViewModel
    {
        public int caseID;
        public int displaycaseID;
        public string station;
        public string date;
        public string time;
        public string race;
        public string detaineereligion;
        public string racismexperiencedatstation;
        public string detaineeage;
        public string racismexperiencedexample;
        public Enum.YesNoEnum hasexperiencedracisminpast;
        public Enum.YesNoEnum hasexperiencedracismincustody;
        public Enum.GenderEnum gender;
        public Enum.YesNoEnum sustainedinjuries;
        public string injurydetail;
        public Enum.YesNoEnum wasstoppedandsearched;
        public string stoppedandsearchedreason;
        public string district;
        public bool drugoffence;
        public bool weaponoffence;
        public bool minorassaultoffence;
        public bool seriousassaultoffence;
        public bool sexualoffence;
        public bool publicorderoffence;
        public bool theftorrobberyoffence;
        public bool fraud;
        public bool driving;
        public bool otheroffence;
        public string committedoffence;


        public Survey Survey { get; set; }

        public Command DeleteSurveyCommand { get; }

        public SurveyDetailViewModel()
        {
            DeleteSurveyCommand = new Command(OnDeleteSurvey);
        }
        public int DisplayCaseID
        {
            get => displaycaseID;
            set => SetProperty(ref displaycaseID, value);
        }
        public int CaseID
        {
            get
            {
                return caseID;
            }
            set
            {
                caseID = value;
                LoadSurveyId(value);
            }
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
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public string DetaineeEthnicity
        {
            get => race;
            set => SetProperty(ref race, value);
        }
        public string DetaineeReligion
        {
            get => detaineereligion;
            set => SetProperty(ref detaineereligion, value);
        }
        public string RacismExperiencedAtStation
        {
            get => racismexperiencedatstation;
            set => SetProperty(ref racismexperiencedatstation, value);
        }
        public string DetaineeAge
        {
            get => detaineeage;
            set => SetProperty(ref detaineeage, value);
        }
        public string RacismExperiencedExample
        {
            get => racismexperiencedexample;
            set => SetProperty(ref racismexperiencedexample, value);
        }
        public Enum.YesNoEnum HasExperiencedRacismInPast
        {
            get => hasexperiencedracisminpast;
            set => SetProperty(ref hasexperiencedracisminpast, value);
        }
        public Enum.YesNoEnum HasExperiencedRacismInCustody
        {
            get => hasexperiencedracismincustody;
            set => SetProperty(ref hasexperiencedracismincustody, value);
        }
        public Enum.GenderEnum Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public Enum.YesNoEnum SustainedInjuries
        {
            get => sustainedinjuries;
            set => SetProperty(ref sustainedinjuries, value);
        }
        public string InjuryDetail
        {
            get => injurydetail;
            set => SetProperty(ref injurydetail, value);
        }
        public Enum.YesNoEnum WasStoppedAndSearched
        {
            get => wasstoppedandsearched;
            set => SetProperty(ref wasstoppedandsearched, value);
        }
        public string StoppedAndSearchedReason
        {
            get => stoppedandsearchedreason;
            set => SetProperty(ref stoppedandsearchedreason, value);
        }
        public string District
        {
            get => district;
            set => SetProperty(ref district, value);
        }
        public bool DrugOffence
        {
            get => drugoffence;
            set => SetProperty(ref drugoffence, value);
        }
        public bool WeaponOffence
        {
            get => weaponoffence;
            set => SetProperty(ref weaponoffence, value);
        }
        public bool MinorAssaultOffence
        {
            get => minorassaultoffence;
            set => SetProperty(ref minorassaultoffence, value);
        }
        public bool SeriousAssaultOffence
        {
            get => seriousassaultoffence;
            set => SetProperty(ref seriousassaultoffence, value);
        }
        public bool SexualOffence
        {
            get => sexualoffence;
            set => SetProperty(ref sexualoffence, value);
        }
        public bool PublicOrderOffence
        {
            get => publicorderoffence;
            set => SetProperty(ref publicorderoffence, value);
        }
        public bool TheftOrRobberyOffence
        {
            get => theftorrobberyoffence;
            set => SetProperty(ref theftorrobberyoffence, value);
        }
        public bool Fraud
        {
            get => fraud;
            set => SetProperty(ref fraud, value);
        }
        public bool Driving
        {
            get => driving;
            set => SetProperty(ref driving, value);
        }
        public bool OtherOffence
        {
            get => otheroffence;
            set => SetProperty(ref otheroffence, value);
        }
        public string CommittedOffence
        {
            get => committedoffence;
            set => SetProperty(ref committedoffence, value);
        }

        public async void OnDeleteSurvey()
        {
            var result = await Application.Current.MainPage.DisplayAlert("WARNING", "Are you sure you want to delete this survey?", "Yes", "No");
            if (result == true)
            {
                try
                {
                    await App.Database.DeleteSurveyAsync(Survey);
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception)
                {
                    Debug.WriteLine("Failed to delete survey");
                }
            }
        }

        public async void LoadSurveyId(int surveyId)
        {
            try
            {
                Survey = await App.Database.GetSurveysAsync_ID_Asc(surveyId);
                DisplayCaseID = surveyId;
                CaseID = Survey.CaseId;
                Station = Survey.Station;
                Date = Survey.Date;
                Time = Survey.Time;
                DetaineeEthnicity = Survey.Race;
                DetaineeReligion = Survey.DetaineeReligion;
                RacismExperiencedAtStation = Survey.RacismExperiencedAtStation;
                DetaineeAge = Survey.DetaineeAge;
                RacismExperiencedExample = Survey.RacismExperiencedExample;
                HasExperiencedRacismInPast = Survey.HasExperiencedRacismInPast;
                HasExperiencedRacismInCustody = Survey.HasExperiencedRacismInCustody;
                Gender = Survey.Gender;
                SustainedInjuries = Survey.SustainedInjuries;
                InjuryDetail = Survey.InjuryDetail;
                WasStoppedAndSearched = Survey.WasStoppedAndSearched;
                StoppedAndSearchedReason = Survey.StoppedAndSearchedReason;
                District = Survey.District;
                DrugOffence = Survey.DrugOffence;
                WeaponOffence = Survey.WeaponOffence;
                MinorAssaultOffence = Survey.MinorAssaultOffence;
                SeriousAssaultOffence = Survey.SeriousAssaultOffence;
                SexualOffence = Survey.SexualOffence;
                PublicOrderOffence = Survey.PublicOrderOffence;
                TheftOrRobberyOffence = Survey.TheftOrRobberyOffence;
                Fraud = Survey.Fraud;
                Driving = Survey.Driving;
                OtherOffence = Survey.OtherOffence;
                CommittedOffence = Survey.CommittedOffence;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Survey");
            }
        }
    }
}