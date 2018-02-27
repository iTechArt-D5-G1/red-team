using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.Repositories.Interfaces;
using System;

namespace RedTeam.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Repository<Survey> Repository;

        public SurveyContext Db { get; }
        public UnitOfWork(SurveyContext _Db, Repository<Survey> _Repository)
        {
            Db = _Db;
            Repository = _Repository;
        }
        public Repository<Survey> Surveys
        {
            get
            { 
                return Repository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        public async void SaveAsync()
        {
            var a = await Db.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        { }
    }
}
