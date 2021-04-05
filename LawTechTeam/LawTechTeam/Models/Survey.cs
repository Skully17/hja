using System;
using SQLite;

namespace LawTechTeam.Models
{
    public class Survey
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string text { get; set; }
        public string description { get; set; }
    }
}