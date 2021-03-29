using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawTechTeam.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddSurveyAsync(T survey);
        Task<bool> UpdateSurveyAsync(T survey);
        Task<bool> DeleteSurveyAsync(string id);
        Task<T> GetSurveyAsync(string id);
        Task<IEnumerable<T>> GetSurveysAsync(bool forceRefresh = false);
    }
}
