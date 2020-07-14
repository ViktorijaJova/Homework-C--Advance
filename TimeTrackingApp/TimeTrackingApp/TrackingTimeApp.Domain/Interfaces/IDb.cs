using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Interfaces
{
   public interface IDb<T> where T:User
    {
        public List<T> GetAllNewWay();
        public T GetUserById(int id);


       public int InsertNewWay(T entity);

        public void UpdateUser(T entity);

/*        public void RemoveUser(int id);
*/






    }
}
