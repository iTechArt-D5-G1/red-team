using System;
using RedTeam.BackendInfrastructure.Repositories;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Repository Surveys { get; }

        SurveyContext Db { get; }

        void SaveAsync();
    }
}
