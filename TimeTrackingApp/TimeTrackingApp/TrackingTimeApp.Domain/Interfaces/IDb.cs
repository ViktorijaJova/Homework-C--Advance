using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Interfaces
{
   public interface IDb<T> where T:User
    {
        public List<T> GetAll();
        public T GetUserbyId(int id);

        public int Insert(T entity);

        public void UpdateUSer(T entity);
        public void RemoveUser(int id);

        public List<BaseEntity> GetAllActivities(int id);
        public BaseEntity GetActivity(ActivityType activity, int id);






    }
}
