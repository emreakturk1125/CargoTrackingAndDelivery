using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        Task<BaseResponse<T>> RemoveBase(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<BaseResponse<T>> RemoveRangeBase(IEnumerable<T> entities);
        T Update(T entity);

    }
}
