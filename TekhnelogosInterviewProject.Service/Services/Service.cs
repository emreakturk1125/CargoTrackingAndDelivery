using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks; 
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        
        public async Task<BaseResponse<T>> AddAsync(T entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return new BaseResponse<T>(entity);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }
  
        public async Task<BaseResponse<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _repository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();
                return new BaseResponse<IEnumerable<T>>(entities);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<T>>(ex.Message);
            }
        }
         
        public async Task<BaseResponse<IEnumerable<T>>> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> response = await this._repository.Find(predicate);
            return new BaseResponse<IEnumerable<T>>(response);
        }
  
        public async Task<BaseResponse<IEnumerable<T>>> GetAllAsync()
        {
            IEnumerable<T> response = await _repository.GetAllAsync();
            return new BaseResponse<IEnumerable<T>>(response);

        }
         
        public async Task<BaseResponse<T>> GetByIdAsync(int id)
        {
            T response = await this._repository.GetByIdAsync(id);
            return new BaseResponse<T>(response);
        }

        public async Task<BaseResponse<T>> RemoveAsync(int id)
        {
            try
            {
                T entity = await this._repository.GetByIdAsync(id);

                if (entity != null)
                {
                    await _repository.RemoveBase(entity);
                    await this._unitOfWork.CommitAsync();
                    return new BaseResponse<T>(entity);
                }
                else
                {
                    return new BaseResponse<T>($"{id} no'lu id'ye ait kayıt bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }
         
        public async Task<BaseResponse<IEnumerable<T>>> RemoveRangeAsync(IEnumerable<T> entities)
        {
            try
            { 
               await _repository.RemoveRangeBase(entities);
               await this._unitOfWork.CommitAsync();
               return new BaseResponse<IEnumerable<T>>(entities);
              
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<T>>(ex.Message);
            }
        }
         
        public async Task<BaseResponse<T>> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                T entity = await _repository.SingleOrDefaultAsync(predicate);

                if (entity != null)
                {
                    return new BaseResponse<T>(entity);
                }
                else
                {
                    return new BaseResponse<T>($"kayıt bulunamadı");

                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }
         
        public async Task<BaseResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                this._repository.Update(entity);
                await this._unitOfWork.CommitAsync();
                return new BaseResponse<T>(entity);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }

       
    }
}
