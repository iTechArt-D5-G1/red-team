﻿using System.Web.Http;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private readonly IServise _servise;
 
        public ValueController(IServise servise)
        {
            _servise = servise;
        }

        public void GetById(int id)
        {
            _servise.GetById(id);
        }
    }
}