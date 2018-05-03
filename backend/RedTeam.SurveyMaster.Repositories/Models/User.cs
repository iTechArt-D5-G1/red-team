using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.SurveyMaster.Repositories.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should set Email")]
        [EmailAddress(ErrorMessage = "Email isn't valid")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You should set Password")]
        [MinLength(6, ErrorMessage = "Min length of password is 6 symbols")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Survey> Surveys { get; set; }


        public User()
        {
            Surveys = new List<Survey>();
        }
    }
}
