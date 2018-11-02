using System.Collections.Generic;
using EFDomain.Models;

namespace EFDomain.Interfaces
{
    public interface IServiceBase<T>
    {
        Weapon GetById(int id);
        IEnumerable<T> GetAllEntities();
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteById(int id);
    }
}