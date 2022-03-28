using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InvestmentsPortfolio.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InvestmentsPortfolioDBContext _dbcontext;
        public Repository(InvestmentsPortfolioDBContext dBContext)
        {
            _dbcontext = dBContext;
        }

        public IEnumerable<T> All()
        {
            var entities = _dbcontext.Set<T>();
            return entities.AsEnumerable();
        }

        public void Create(IList<T> entities)
        {
            _dbcontext.AddRange(entities);
            _dbcontext.SaveChanges();
        }


        public void Delete(T entity)
        {
            _dbcontext.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public T First()
        {
            var entity = _dbcontext.Set<T>();
            return entity.First();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> clause)
        {
            var entity = _dbcontext.Set<T>();
            return entity.FirstOrDefault(clause);
        }

        public void Update(T entity)
        {
            _dbcontext.Update(entity);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> clause)
        {
            var entity = _dbcontext.Set<T>();
            return entity.Where(clause);
        }

        T IRepository<T>.Create(T entity)
        {
            _dbcontext.Add(entity);
            _dbcontext.SaveChanges();
            return entity;
        }
    }
}

