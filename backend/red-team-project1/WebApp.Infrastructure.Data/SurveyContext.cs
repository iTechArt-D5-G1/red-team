using System.Data.Entity;
using WebApp.Domain.Core;

namespace WebApp.Infrastructure.Data
{
    public class SurveyContext: DbContext
    {
        public SurveyContext() : base("MyDataBase")
        { }
        public DbSet<Survey> Surveys { get; set; }
    }
}
