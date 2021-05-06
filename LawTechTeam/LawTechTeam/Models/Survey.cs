using System;
using LawTechTeam.Enum;
using SQLite;

namespace LawTechTeam.Views
{
    public class Survey
    {
        [PrimaryKey, AutoIncrement]
        public int CaseId { get; set; }
        public string Station { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Race { get; set; }
        public string DetaineeReligion { get; set; }
        public string RacismExperiencedAtStation { get; set; }
        public string DetaineeAge { get; set; }
        public string RacismExperiencedExample { get; set; }
        public YesNoEnum HasExperiencedRacismInPast { get; set; }
        public YesNoEnum HasExperiencedRacismInCustody { get; set; }
        public GenderEnum Gender { get; set; }
        public YesNoEnum SustainedInjuries { get; set; }
        public string InjuryDetail { get; set; }
        public YesNoEnum WasStoppedAndSearched { get; set; }
        public string StoppedAndSearchedReason { get; set; }
        public string District { get; set; }
        public bool DrugOffence { get; set; }
        public bool WeaponOffence { get; set; }
        public bool MinorAssaultOffence { get; set; }
        public bool SeriousAssaultOffence { get; set; }
        public bool SexualOffence { get; set; }
        public bool PublicOrderOffence { get; set; }
        public bool TheftOrRobberyOffence { get; set; }
        public bool Fraud { get; set; }
        public bool Driving { get; set; }
        public bool OtherOffence { get; set; }
        public string CommittedOffence { get; set; }
    }

}