using System.Data.Entity;

namespace WebApp.Domain.Core
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
    }
}