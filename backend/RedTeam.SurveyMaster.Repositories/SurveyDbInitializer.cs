using System.Data.Entity;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.SurveyMaster.Repositories
{
    public sealed class SurveyDbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            db.Objects.Add(new Survey { Name = "первый опрос" });
            db.Objects.Add(new Survey { Name = "второй опрос" });
            db.Objects.Add(new Survey { Name = "третий опрос" });

            base.Seed(db);
        }
    }
}
