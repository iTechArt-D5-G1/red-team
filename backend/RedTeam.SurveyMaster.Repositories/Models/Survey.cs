using System;

namespace RedTeam.SurveyMaster.Repositories.Models
{
    public class Survey 
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
