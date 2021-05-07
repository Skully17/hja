using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;

namespace LawTechTeam.Services
{
    public class RegUserTable
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RepresentativePIN { get; set; }
        public string SupervisorPIN { get; set; }
 
    }
}
