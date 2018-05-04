using System.ComponentModel.DataAnnotations;

namespace RedTeam.SurveyMaster.Repositories.DataTransferObjectModels
{
    public class UserDto
    {
        [Required(ErrorMessage = "You should set Email")]
        [EmailAddress(ErrorMessage = "Email isn't valid")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You should set Password")]
        [MinLength(6, ErrorMessage = "Min length of password is 6 symbols")]
        public string Password { get; set; }
    }
}
