using System;
using System.Collections.Generic;
using System.Linq;
using DevDay.DAL;
using DevDay.Models;

namespace DevDay.Repository
{
    public class RetroRepository : IRetroRepository
    {
        private readonly DevDayContext _dbContext;

        public RetroRepository()
        {
            _dbContext = new DevDayContext();
        }

        public IEnumerable<RetroModel> FindAll()
        {
            return _dbContext.Retros.ToList();
        }

        public IEnumerable<RetroModel> Find(int retroId)
        {
            return _dbContext.Retros.Where(x => x.RetroNumber == retroId).ToList();
        }

        public RetroModel Get(Guid idRetro)
        {
            return _dbContext.Retros.FirstOrDefault(x => x.IdRetro == idRetro);
        }

        public void Save(RetroModel entity)
        {
            _dbContext.Retros.Attach(entity);
        }

        public void Delete(RetroModel entity)
        {
            _dbContext.Retros.Remove(entity);
        }
    }
}