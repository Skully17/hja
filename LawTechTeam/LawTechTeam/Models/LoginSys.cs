using System;
using SQLite;

namespace LawTechTeam.Models
{
    public class LoginSys
    {
        [PrimaryKey, AutoIncrement]
        public string AccUsername { get; set; }
        public string AccPassword { get; set; }
        public string AccAdmin { get; set; }
    }
}