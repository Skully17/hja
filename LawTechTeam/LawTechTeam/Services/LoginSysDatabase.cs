using System.Collections.Generic;
using System.Threading.Tasks;
using LawTechTeam.Models;
using SQLite;

namespace LawTechTeam.Services
{
    public class LoginSysDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LoginSysDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LoginSys>().Wait();
        }

        public Task<List<LoginSys>> GetLoginSysAsync()
        {
            return database.Table<LoginSys>().ToListAsync();
        }

        public Task<LoginSys> GetLoginSysAsync(int id)
        {
            return database.Table<LoginSys>().Where(i => i.AccUsername == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginSysAsync(LoginSys loginsys)
        {
            if (loginsys.AccUsername != "")
            {
                return database.UpdateAsync(loginsys);
            }
            else
            {
                return database.InsertAsync(loginsys);
            }
        }

        public Task<int> DeleteLoginSysAsync(LoginSys loginsys)
        {
            return database.DeleteAsync(loginsys);
        }
    }
}
