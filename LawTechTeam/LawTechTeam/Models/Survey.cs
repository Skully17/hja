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
        public string RacismExperiencedAtStation { get; set; }
        public string DetaineeAge { get; set; }
        public string RacismExperiencedExample { get; set; }
        public YesNoEnum HasExperiencedRacismInPast { get; set; }
        public YesNoEnum HasExperiencedRacismInCustody { get; set; }
        public GenderEnum Gender { get; set; }
        public YesNoEnum SustainedInjuries { get; set; }
        public string InjuryDetail { get; set; }
    }

}