using System;
using SQLite;

namespace LawTechTeam.Models
{
    public class Survey
    {
        [PrimaryKey, AutoIncrement]
        public int CaseId { get; set; }
        public string Station { get; set; }
        public string Date { get; set; }
    }
}