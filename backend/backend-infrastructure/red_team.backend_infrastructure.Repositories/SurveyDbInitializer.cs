using red_team.backend_infrastructure.Foundation;
using System.Data.Entity;

namespace red_team.backend_infrastructure.Repositories
{
    public class SurveyDbInitializer : DropCreateDatabaseAlways<SurveyContext>
    {
        protected override void Seed(SurveyContext db)
        {
            db.Surveys.Add(new Survey { Name = "первый опрос", CreationDate = "1.1.11" });
            db.Surveys.Add(new Survey { Name = "второй опрос", CreationDate = "2.2.12" });
            db.Surveys.Add(new Survey { Name = "третий опрос", CreationDate = "3.3.13" });
            base.Seed(db);
        }
    }
}
