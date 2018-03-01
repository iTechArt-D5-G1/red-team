using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.Repositories.Interfaces;
using System;

namespace RedTeam.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public SurveyContext Db { get; }

        public Repository Surveys { get; }


        public UnitOfWork(SurveyContext db, Repository repository)
        {
            Db = db;
            Surveys = repository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        public async void SaveAsync()
        {
            await Db.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        { }
    }
}
