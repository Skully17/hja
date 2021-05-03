using System;
using System.Collections.Generic;
using System.Text;

namespace LawTechTeam.Services
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RepresentativePIN { get; set; }
        public string SupervisorPIN { get; set; }

    }
}
