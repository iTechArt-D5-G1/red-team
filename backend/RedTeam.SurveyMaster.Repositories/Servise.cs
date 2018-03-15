using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public class Servise: IServise
    {
        private readonly IUnitOfWork _unit;

        private readonly IRepository<Survey> _repository;        

        public Servise(IUnitOfWork unit, IRepository<Survey> repository)
        {
            _unit = unit;
            _repository = repository;
        }

        public Survey GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Save()
        {
            _repository.SaveAsync();
        }

        //public void GetById(int id)
        //{
        //    using (null)
        //    {
        //        try
        //        {
        //            _unit.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            _unit.Rollback();
        //        }
        //    }
        //}
    }
}
