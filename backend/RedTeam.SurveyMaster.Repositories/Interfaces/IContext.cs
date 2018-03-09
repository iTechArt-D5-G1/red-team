﻿using System.Data.Entity;
using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Repositories.Interfaces
{
    public interface IContext<T> where T: class 
    {
        DbSet<T> Objects { get; set; }

        Task<int> SaveChangesAsync();

        T GetById(int id);
    }
}