using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaaS.DataLayer.DataModels;

namespace DaaS.DataLayer.Repository.Base
{
    public interface IRepository<T> where T : BaseEntity
    { 
        IEnumerable<T> GetAll();
        T GetById(string id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(string id);
    }
}