﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}