using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository
{
    public interface IRepository<T>
    {
        T GetItemById(Guid id);
        IQueryable<T> GetAllItems();
        Guid Add(T item);
        Guid Update(T item);
        Guid Remove(Guid id);
        void Save();
    }
}
