using System.Collections.Generic;

namespace desafio_crud_series.Repository
{
    public interface IBaseRepository<T> 
    {
        List<T> GetItems();
        T GetByID(int id);
        void Add(T item);
        void RemoveByID(int id);
        void Update(int id, T item);
        int AvailableID();
    }
}