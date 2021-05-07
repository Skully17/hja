using System.Collections.Generic;
using System.Threading.Tasks;
using LawTechTeam.Views;
using SQLite;

namespace LawTechTeam.Services
{
    public class SurveyDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SurveyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Survey>().Wait();
            database.CreateTableAsync<RegUserTable>().Wait();
        }

        public Task<List<Survey>> GetSurveysAsync_ID_Desc() //Sort by ID (descending) - default view
        {
                return database.Table<Survey>().OrderByDescending(a => a.CaseId).ToListAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_ID_Asc() //Sort by ID (ascending)
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_ID_Asc(int id) //Sort by ID (ascending)
        {
            return database.Table<Survey>().Where(i => i.CaseId == id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Station_Desc() //Sort by Station (descending)
        {
            return database.Table<Survey>().OrderByDescending(a => a.Station).ToListAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Station_Asc() //Sort by Station (ascending)
        {
            return database.Table<Survey>().OrderBy(a => a.Station).ToListAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Date_Desc() //Sort by Date (descending)
        {
            return database.Table<Survey>().OrderByDescending(a => a.Date).ThenByDescending(a => a.Time).ToListAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Date_Asc() //Sort by Date (ascending)
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Search(string search) //Show searched survey
        {
            int.TryParse(search, out int test);

            return database.Table<Survey>().Where(a => a.Station.ToLower().Contains(search) || a.Date.ToLower().Contains(search) || a.CaseId == test).OrderByDescending(a => a.CaseId).ToListAsync();
        }

        public Task<int> SaveSurveyAsync(Survey survey)
        {
            if (survey.CaseId != 0)
            {
                return database.UpdateAsync(survey);
            }
            else
            {
                return database.InsertAsync(survey);
            }
        }

        public Task<int> DeleteSurveyAsync(Survey survey)
        {
            return database.DeleteAsync(survey);
        }

        public Task<List<RegUserTable>> GetUsers()
        {
            return database.Table<RegUserTable>().ToListAsync();
        }
        public Task<RegUserTable> GetUser(int user_id)
        {
            return database.Table<RegUserTable>().Where(i => i.UserId == user_id).FirstOrDefaultAsync();
        }
        public void SaveUserAsync(RegUserTable user)
        {
            if (user.Email == null || user.Password == null || user.Admin == null || user.FirstName == null || user.LastName == null || user.RepresentativePIN == null)
            {
                App.Current.MainPage.DisplayAlert("Error", "Not all required details have been entered", "Ok");
            }

            else if (user.UserId != 0)
            {
                database.UpdateAsync(user);
            }
            else
            {
                database.InsertAsync(user);
            }
        }
        public Task<RegUserTable> ValidateLogin(string email, string password)
        {
            return database.Table<RegUserTable>().Where(u => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefaultAsync();
        }
    }
}
