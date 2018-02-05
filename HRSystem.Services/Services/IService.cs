using System;
using System.Linq;

namespace HRSystem.Service.Services
{
    public interface IService<T>
    {
        IQueryable<T> GetAllItems();
        T GetItemById(Guid id);
        Guid Add(T item);
        Guid Update(T item);
        Guid Remove(T item);
    }
}
