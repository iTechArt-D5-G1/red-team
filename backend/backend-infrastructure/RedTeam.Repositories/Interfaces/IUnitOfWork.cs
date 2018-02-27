using System;
using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.BackendInfrastructure.Repositories;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Repository<Survey> Surveys { get; }
        SurveyContext Db { get; }
    }
}
