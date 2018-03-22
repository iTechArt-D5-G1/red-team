using System;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public class SurveyServise: ISurveyServise
    {
        private readonly IUnitOfWork _unit;

        private readonly IRepository<Survey> _repository;


        public SurveyServise(IUnitOfWork unit, IRepository<Survey> repository)
        {
            _unit = unit;
            _repository = repository;
        }

        public Survey GetById(int id)
        {
            using (var unit =_unit)
            {
                try
                {
                    return _repository.GetById(id);
                }
                catch (Exception)
                {
                    unit.Rollback();
                    throw;
                }
            }
        }
    }
}
