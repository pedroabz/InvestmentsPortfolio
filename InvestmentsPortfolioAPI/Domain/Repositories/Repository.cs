using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InvestmentsPortfolioAPI.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
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

        public T First()
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> clause)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> clause)
        {
            throw new NotImplementedException();
        }
    }

}
