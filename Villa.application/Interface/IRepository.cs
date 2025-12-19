using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T,bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        bool AnyFilter(Expression<Func<T, bool>> filter);
      
    }
}
