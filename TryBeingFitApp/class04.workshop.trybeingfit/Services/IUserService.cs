using System;
using System.Collections.Generic;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;

namespace class04.workshop.trybeingfit.Services.Services
{
    public interface IUserService<T> where T : User
    {
        void ChangePassword(int userId, string oldPassword, string newPassword);
        void ChangeInfo(int userId, string firstName, string lastName);
        T LogIn(string username, string password);
        T Register(T user);
        T GetById(int id);
    }
}
