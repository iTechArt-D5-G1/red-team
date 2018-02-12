using System.Data.Entity;
using WebApp.Domain.Core;

namespace WebApp.Services.Interfaces
{
    public class SurveyContext: DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
    }
}
