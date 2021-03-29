using LawTechTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawTechTeam.Services
{
    public class MockDataStore : IDataStore<Survey>
    {
        readonly List<Survey> surveys;

        public MockDataStore()
        {
            surveys = new List<Survey>()
            {
                new Survey { Id = Guid.NewGuid().ToString(), Text = "First survey", Description="This is an survey description." },
                new Survey { Id = Guid.NewGuid().ToString(), Text = "Second survey", Description="This is an survey description." },
                new Survey { Id = Guid.NewGuid().ToString(), Text = "Third survey", Description="This is an survey description." },
                new Survey { Id = Guid.NewGuid().ToString(), Text = "Fourth survey", Description="This is an survey description." },
                new Survey { Id = Guid.NewGuid().ToString(), Text = "Fifth survey", Description="This is an survey description." },
                new Survey { Id = Guid.NewGuid().ToString(), Text = "Sixth survey", Description="This is an survey description." }
            };
        }

        public async Task<bool> AddSurveyAsync(Survey survey)
        {
            surveys.Add(survey);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSurveyAsync(Survey survey)
        {
            var oldSurvey = surveys.Where((Survey arg) => arg.Id == survey.Id).FirstOrDefault();
            surveys.Remove(oldSurvey);
            surveys.Add(survey);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSurveyAsync(string id)
        {
            var oldSurvey = surveys.Where((Survey arg) => arg.Id == id).FirstOrDefault();
            surveys.Remove(oldSurvey);

            return await Task.FromResult(true);
        }

        public async Task<Survey> GetSurveyAsync(string id)
        {
            return await Task.FromResult(surveys.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Survey>> GetSurveysAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(surveys);
        }
    }
}