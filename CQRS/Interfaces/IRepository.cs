﻿namespace CQRS.Interfaces;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id); 
    Task<IEnumerable<T>> GetAllAsync(); 
    Task AddAsync(T entity); 
    Task UpdateAsync(T entity); 
    Task DeleteAsync(T entity); 
    Task SaveAsync();
}