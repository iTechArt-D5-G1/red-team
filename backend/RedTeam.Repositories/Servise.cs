﻿using System;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.Repositories
{
    public class Servise: IServise
    {
        private readonly IUnitOfWork _unit;

        public Servise(IUnitOfWork unit)
        {
            _unit = unit;
        } 

        public Survey GetById(int id)
        {
            using (null)
            {
                try
                {
                    return _unit.GetById(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
