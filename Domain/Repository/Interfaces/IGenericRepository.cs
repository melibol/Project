using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository.Interfaces
{
    public interface IGenericRepository<Tentity> where Tentity:class,new()
    {
        bool Insert(Tentity entity);
        bool Delete(Tentity entity);
        bool Update(Tentity entity);

        bool SoftDelete(Tentity entity);

        //void Dispose();

        IQueryable<Tentity> GetAll();
        Tentity GetById(int id);
    }
}
