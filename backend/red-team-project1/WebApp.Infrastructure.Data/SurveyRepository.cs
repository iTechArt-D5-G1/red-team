using System;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;

namespace WebApp.Infrastructure.Data
{
    public class SurveyRepository : ISurveyRepository
    {
        private SurveyContext db = new SurveyContext();
        public Survey GetSurveyById(int id)
        {
            return db.Surveys.Find(id);
        }
    }
}
