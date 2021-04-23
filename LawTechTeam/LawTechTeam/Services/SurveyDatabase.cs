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

        public Task<List<Survey>> GetSurveysAsync()
        {
            return database.Table<Survey>().ToListAsync();
        }

        public Task<Survey> GetSurveyAsync(int id)
        {
            return database.Table<Survey>().Where(i => i.CaseID== id).FirstOrDefaultAsync();
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
