using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;

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

    public class test 
    {
        readonly SQLiteAsyncConnection database;

        public test(string dbPath)
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<RegUserTable>().Wait();
            }

            public Task<List<RegUserTable>> GetUsersAsync()
            {
                return database.Table<RegUserTable>().ToListAsync();
            } 
    }
}
