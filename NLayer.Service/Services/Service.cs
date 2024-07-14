using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class Service<T> : IService<T> where T : class
{
    private readonly IGenericRepository<T> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return await _genericRepository.GetAll().ToListAsync();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _genericRepository.Where(expression);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T>AddAsync(T entity)
    {
       await _genericRepository.AddAsync(entity);
       await _unitOfWork.CommitAsync();
       return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _genericRepository.AddRangeAsync(entities);
        await _unitOfWork.CommitAsync();
        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
         _genericRepository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _genericRepository.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _genericRepository.RemoveRange(entities);
        await _unitOfWork.CommitAsync();
    }
}