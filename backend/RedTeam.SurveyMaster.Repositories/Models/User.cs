using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RedTeam.SurveyMaster.Repositories.Models
{
    public class User : IdentityUser
    {
        public ICollection<Survey> Surveys { get; set; }


        public User()
        {
            Surveys = new List<Survey>();
        }
    }
}
