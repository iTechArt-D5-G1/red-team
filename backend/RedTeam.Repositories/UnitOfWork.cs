using System;
using RedTeam.Repositories.Interfaces;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        readonly IRepository<Survey> _repository;

        public UnitOfWork(IRepository<Survey> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        public Survey GetById(int id)
        {
           return _repository.GetById(id);
        }

        public void Save()
        {
             _repository.SaveAsync();
        }


        protected virtual void Dispose(bool disposing)
        { }

        Task IUnitOfWork.Save()
        {
            throw new NotImplementedException();
        }
    }
}
