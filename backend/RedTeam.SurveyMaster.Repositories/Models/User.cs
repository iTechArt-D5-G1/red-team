using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Repositories.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should set Email")]
        [EmailAddress(ErrorMessage = "Email isn't valid")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You should set Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
