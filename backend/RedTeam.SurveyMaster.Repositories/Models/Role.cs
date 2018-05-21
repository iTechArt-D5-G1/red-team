using Microsoft.AspNet.Identity.EntityFramework;

namespace RedTeam.SurveyMaster.Repositories.Models
{
    public class Role : IdentityRole
    {
        public Role()
        {}

        public Role(string roleName) : base(roleName)
        {
        }
    }
}
