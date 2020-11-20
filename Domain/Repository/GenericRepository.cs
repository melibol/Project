using Domain.Abstract;
using Domain.Context;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class GenericRepository<Tentity> where Tentity : class, IBaseEntity, new()
    {
        public NewsContext context = null;
        private DbSet<Tentity> _dbset;

        public GenericRepository()
        {
            context = new NewsContext();
            _dbset = context.Set<Tentity>();
            //_/*dbset.Where(x => x.)*/
        }

        public bool Insert(Tentity entity)
        {
            _dbset.Add(entity);
            //entity.IsDeleted = false;
           return context.SaveChanges() > 0;
        }

        public Tentity GetById(int id)
        {
            return _dbset.Find(id);
        }

        public bool Delete(Tentity tentity)
        {
            _dbset.Remove(tentity);
            return context.SaveChanges() > 0;
        }

        public bool SoftDelete(Tentity entity)
        {
            var bul = GetById(entity.Id);
            bul.IsDeleted = true;
            return context.SaveChanges() > 0;
        }

        public bool Update(Tentity entity)
        {
            _dbset.Update(entity);
            return context.SaveChanges() > 0;
        }

        public IQueryable<Tentity> GetAll()
        {
            return _dbset;
        }


    }
}
