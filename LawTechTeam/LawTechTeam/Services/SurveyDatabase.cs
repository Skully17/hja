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
        }

        public Task<List<Survey>> GetSurveysAsync_ID_Desc() //Sort by ID (descending) - default view
        {
                return database.Table<Survey>().OrderByDescending(a => a.CaseID).ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_ID_Desc(int id) //Sort by ID (descending) - default view
        {
            return database.Table<Survey>().Where(i => i.CaseID== id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_ID_Asc() //Sort by ID (ascending)
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_ID_Asc(int id) //Sort by ID (ascending)
        {
            return database.Table<Survey>().Where(i => i.CaseID == id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Station_Desc() //Sort by Station (descending)
        {
            return database.Table<Survey>().OrderByDescending(a => a.Station).ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_Station_Desc(int id) //Sort by Station (descending)
        {
            return database.Table<Survey>().Where(i => i.CaseID == id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Station_Asc() //Sort by Station (ascending)
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_Station_Asc(int id) //Sort by Station (ascending)
        {
            return database.Table<Survey>().Where(i => i.CaseID == id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Date_Desc() //Sort by Date (descending)
        {
            return database.Table<Survey>().OrderByDescending(a => a.Date).ThenByDescending(a => a.Time).ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_Date_Desc(int id) //Sort by Date (descending)
        {
            return database.Table<Survey>().Where(i => i.CaseID == id).FirstOrDefaultAsync();
        }

        public Task<List<Survey>> GetSurveysAsync_Date_Asc() //Sort by Date (ascending)
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<Survey> GetSurveysAsync_Date_Asc(int id) //Sort by Date (ascending)
        {
            return database.Table<Survey>().Where(i => i.CaseID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveSurveyAsync(Survey survey)
        {
            if (survey.CaseID != 0)
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

    }
}
