using RedTeam.BackendInfrastructure.Foundation;
using System.Data.Entity;

namespace RedTeam.BackendInfrastructure.Repositories
{
    public sealed class SurveyDbInitializer : DropCreateDatabaseAlways<Context<Survey>>
    {
        protected override void Seed(Context<Survey> db)
        {
            db.Objects.Add(new Survey { Name = "первый опрос" });
            db.Objects.Add(new Survey { Name = "второй опрос" });
            db.Objects.Add(new Survey { Name = "третий опрос" });

            base.Seed(db);
        }
    }
}
