using System;

namespace RedTeam.BackendInfrastructure.Foundation
{
    public class Survey : IDisposable
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
