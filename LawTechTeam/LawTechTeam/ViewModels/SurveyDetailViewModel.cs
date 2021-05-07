using LawTechTeam.Views;
using LawTechTeam.Enum;
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
        public string modifieddate;
        public string modifiedtime;
        public string race;
        public string detaineereligion;
        public string racismexperiencedatstation;
        public string detaineeage;
        public string racismexperiencedexample;
        public Enum.YesNoEnum hasexperiencedracisminpast;
        public int yeshasexperiencedracisminpast;
        public int nohasexperiencedracisminpast;
        public Enum.YesNoEnum hasexperiencedracismincustody;
        public int yeshasexperiencedracismincustody;
        public int nohasexperiencedracismincustody;
        public Enum.GenderEnum gender;
        public int malegender;
        public int femalegender;
        public int othergender;
        public int pntsgender;
        public Enum.YesNoEnum sustainedinjuries;
        public int yessustainedinjuries;
        public int nosustainedinjuries;
        public string injurydetail;
        public Enum.YesNoEnum wasstoppedandsearched;
        public int yesstoppedandsearched;
        public int nostoppedandsearched;
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

        public string updatedracismexperiencedincustody;


        public Survey Survey { get; set; }
        public Command SaveCommand { get; }
        public Command DeleteSurveyCommand { get; }

        public SurveyDetailViewModel()
        {
            SaveCommand = new Command(OnSave);
            DeleteSurveyCommand = new Command(OnDeleteSurvey);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
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
        public string ModifiedDate
        {
            get => modifieddate;
            set => SetProperty(ref modifieddate, value);
        }
        public string ModifiedTime
        {
            get => modifiedtime;
            set => SetProperty(ref modifiedtime, value);
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
        public int YesHasExperiencedRacismInPast
        {
            get => yeshasexperiencedracisminpast;
            set => SetProperty(ref yeshasexperiencedracisminpast, value);
        }
        public int NoHasExperiencedRacismInPast
        {
            get => nohasexperiencedracisminpast;
            set => SetProperty(ref nohasexperiencedracisminpast, value);
        }
        public Enum.YesNoEnum HasExperiencedRacismInCustody
        {
            get => hasexperiencedracismincustody;
            set => SetProperty(ref hasexperiencedracismincustody, value);
        }
        public int YesHasExperiencedRacismInCustody
        {
            get => yeshasexperiencedracismincustody;
            set => SetProperty(ref yeshasexperiencedracismincustody, value);
        }
        public int NoHasExperiencedRacismInCustody
        {
            get => nohasexperiencedracismincustody;
            set => SetProperty(ref nohasexperiencedracismincustody, value);
        }
        public Enum.GenderEnum Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public int Male
        {
            get => malegender;
            set => SetProperty(ref malegender, value);
        }
        public int Female
        {
            get => femalegender;
            set => SetProperty(ref femalegender, value);
        }
        public int Other
        {
            get => othergender;
            set => SetProperty(ref othergender, value);
        }
        public int PreferNotToSay
        {
            get => pntsgender;
            set => SetProperty(ref pntsgender, value);
        }
        public Enum.YesNoEnum SustainedInjuries
        {
            get => sustainedinjuries;
            set => SetProperty(ref sustainedinjuries, value);
        }
        public int YesSustainedInjuries
        {
            get => yessustainedinjuries;
            set => SetProperty(ref yessustainedinjuries, value);
        }
        public int NoSustainedInjuries
        {
            get => nosustainedinjuries;
            set => SetProperty(ref nosustainedinjuries, value);
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
        public int YesStoppedAndSearched
        {
            get => yesstoppedandsearched;
            set => SetProperty(ref yesstoppedandsearched, value);
        }
        public int NoStoppedAndSearched
        {
            get => nostoppedandsearched;
            set => SetProperty(ref nostoppedandsearched, value);
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
                Station = Survey.Station;
                Date = Survey.Date;
                Time = Survey.Time;
                ModifiedDate = Survey.ModifiedDate;
                ModifiedTime = Survey.ModifiedTime;
                DetaineeEthnicity = Survey.Race;
                DetaineeReligion = Survey.DetaineeReligion;
                RacismExperiencedAtStation = Survey.RacismExperiencedAtStation;
                DetaineeAge = Survey.DetaineeAge;
                RacismExperiencedExample = Survey.RacismExperiencedExample;
                HasExperiencedRacismInPast = Survey.HasExperiencedRacismInPast;
                YesHasExperiencedRacismInPast = Survey.YesHasExperiencedRacismInPast;
                NoHasExperiencedRacismInPast = Survey.NoHasExperiencedRacismInPast;
                HasExperiencedRacismInCustody = Survey.HasExperiencedRacismInCustody;
                YesHasExperiencedRacismInCustody = Survey.YesHasExperiencedRacismInCustody;
                NoHasExperiencedRacismInCustody = Survey.NoHasExperiencedRacismInCustody;
                Gender = Survey.Gender;
                Male = Survey.Male;
                Female = Survey.Female;
                Other = Survey.Other;
                PreferNotToSay = Survey.PreferNotToSay;
                SustainedInjuries = Survey.SustainedInjuries;
                YesSustainedInjuries = Survey.YesSustainedInjuries;
                NoSustainedInjuries = Survey.NoSustainedInjuries;
                InjuryDetail = Survey.InjuryDetail;
                WasStoppedAndSearched = Survey.WasStoppedAndSearched;
                YesStoppedAndSearched = Survey.YesStoppedAndSearched;
                NoStoppedAndSearched = Survey.NoStoppedAndSearched;
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

        
        private async void OnSave()
        {
            Survey = await App.Database.GetSurveysAsync_ID_Asc(Survey.CaseId);
            Survey newSurvey = new Survey
            {
                CaseId = Survey.CaseId,
                Station = Survey.Station,
                Date = Survey.Date,
                Time = Survey.Time,
                ModifiedDate = $"{DateTime.Now:dd/MM/yyyy}",
                ModifiedTime = $"{DateTime.Now:HH:mm}",
                HasExperiencedRacismInCustody = YesHasExperiencedRacismInCustody > 0 ? YesNoEnum.Yes : NoHasExperiencedRacismInCustody > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                YesHasExperiencedRacismInCustody = YesHasExperiencedRacismInCustody,
                NoHasExperiencedRacismInCustody = NoHasExperiencedRacismInCustody,
                RacismExperiencedAtStation = RacismExperiencedAtStation,
                SustainedInjuries = YesSustainedInjuries > 0 ? YesNoEnum.Yes : NoSustainedInjuries > 0 ? YesNoEnum.No : YesNoEnum.Unanswered,
                YesSustainedInjuries = YesSustainedInjuries,
                NoSustainedInjuries = NoSustainedInjuries,
                InjuryDetail = InjuryDetail,
                DetaineeAge = DetaineeAge,
                Gender = Male > 0 ? GenderEnum.Male : Female > 0 ? GenderEnum.Female : Other > 0 ? GenderEnum.Other : PreferNotToSay > 0 ? GenderEnum.PreferNotToSay : GenderEnum.Unanswered,
                Male = Male,
                Female = Female,
                Other = Other,
                PreferNotToSay = PreferNotToSay,
                DetaineeReligion = DetaineeReligion,
                Race = DetaineeEthnicity,
                District = District,
                DrugOffence = DrugOffence,
                WeaponOffence = WeaponOffence,
                MinorAssaultOffence = MinorAssaultOffence,
                SeriousAssaultOffence = SeriousAssaultOffence,
                SexualOffence = SexualOffence,
                PublicOrderOffence = PublicOrderOffence,
                TheftOrRobberyOffence = TheftOrRobberyOffence,
                Fraud = Fraud,
                Driving = Driving,
                OtherOffence = OtherOffence,
                CommittedOffence = CommittedOffence,
                YesHasExperiencedRacismInPast = YesHasExperiencedRacismInPast,
                NoHasExperiencedRacismInPast = NoHasExperiencedRacismInPast,
                RacismExperiencedExample = RacismExperiencedExample,
                YesStoppedAndSearched = YesStoppedAndSearched,
                NoStoppedAndSearched = NoStoppedAndSearched,
                StoppedAndSearchedReason = StoppedAndSearchedReason,
            };
            
            await App.Database.SaveSurveyAsync(newSurvey);
            

        }
    }
}