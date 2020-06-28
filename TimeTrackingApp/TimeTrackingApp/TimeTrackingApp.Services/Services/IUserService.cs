using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;

namespace TimeTrackingApp.Services.Services
{
     public interface IUserService<T> where T:User
    {

        void ChangePassword(int id, string oldPassword, string newPassword);
        void ChangeInfo(int id, string firstName, string lastName);
        T LogIn(string username, string password);
        T Register(T user);
        public void DeactivateAccount(int id);
        public void SeeStatistics(User user);



    }
}
