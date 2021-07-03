using System.Collections.Generic;
using desafio_crud_series.Models;

namespace desafio_crud_series.Repository
{
    public class DataRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private List<T> Items = new List<T>();

        public void Add(T item)
        {
            Items.Add(item);
        }

        public List<T> GetItems()
        {
            return Items;
        }

        public T GetByID(int id)
        {
            return Items[id];
        }

        public void Update(int id, T item)
        {
            Items[id] = item;
        }

        public void RemoveByID(int id)
        {
            Items[id].SetDeleted();
        }

        public int AvailableID()
        {
            return Items.Count;
        }
    }
}