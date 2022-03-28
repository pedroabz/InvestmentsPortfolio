using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvestmentsPortfolio.Domain.Repositories
{
    public interface IRepository<T> where T: class
    {
        T Create(T entity);

        void Create(IList<T> entities);

        void Update(T entity);

        T FirstOrDefault(Expression<Func<T, bool>> clause);

        IEnumerable<T> Where(Expression<Func<T, bool>> clause);       

        T First();

        IEnumerable<T> All();

        void Delete (T entity);
    }
}
