using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;

namespace workshop.TryBeingFit.Domain.Db
{
  public interface IDb<T> where T: BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Remove(int id);
        void Update(T entity);

    }
}
