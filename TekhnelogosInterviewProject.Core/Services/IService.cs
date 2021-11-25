using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks; 
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Core.Services
{
    public interface IService<T> where T : class
    {
    //    Task<T> GetByIdAsync(int id);
        Task<BaseResponse<T>> GetByIdAsync(int id);

        //Task<IEnumerable<T>> GetAllAsync();
        Task<BaseResponse<IEnumerable<T>>> GetAllAsync();

        //Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<BaseResponse<IEnumerable<T>>> Find(Expression<Func<T, bool>> predicate);


        //Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<BaseResponse<T>> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);


        //Task<T> AddAsync(T entity);
        Task<BaseResponse<T>> AddAsync(T entity);

        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<BaseResponse<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities);

        //void Remove(T entity);
        Task<BaseResponse<T>> RemoveAsync(int id);

        //void RemoveRange(IEnumerable<T> entities);
        Task<BaseResponse<IEnumerable<T>>> RemoveRangeAsync(IEnumerable<T> entities);

        //T Update(T entity);
        Task<BaseResponse<T>> UpdateAsync(T entity);
    }
}
