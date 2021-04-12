using System;
using SQLite;

namespace LawTechTeam.Models
{
    public class Survey
    {
        [PrimaryKey, AutoIncrement]
        public int CaseID { get; set; }
        public string Station { get; set; }
        public string Date { get; set; }
        public int Race { get; set; }
        public string RacismExperience { get; set; }
        public string RacismExperiencedAtStation { get; set; }
        public string DetaineeAge { get; set; }
        public string IsUkCitizen { get; set; }
        public string RacismExperiencedAtStationExamples { get; set; }
        public string RacismExperiencedExample { get; set; }
    }
}