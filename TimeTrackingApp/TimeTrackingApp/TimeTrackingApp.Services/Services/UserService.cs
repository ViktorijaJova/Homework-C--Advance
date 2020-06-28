using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TimeTrackingApp.Services.Helpers;
using TrackingTimeApp.Domain;
using TrackingTimeApp.Domain.Entities;

namespace TimeTrackingApp.Services.Services
{
    public class UserService<T> : IUserService<T> where T : User
    {

        private Db<T> _db;
        public UserService()
        {
            _db = new Db<T>();
        }

        public void ChangeInfo(int id, string firstName, string lastName)
        {
            T user = _db.GetUserbyId(id);
            if (Validation.ValidateString(firstName) == null
                || Validation.ValidateString(lastName) == null)
            {
                Console.WriteLine("[Error] strings were not valid. Please try again!", ConsoleColor.Red);
                return;
            }
            user.FirstName = firstName;
            user.LastName = lastName;
            _db.UpdateUSer(user);
            Console.WriteLine("Data successfuly changed!", ConsoleColor.Green);
        }




        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            T user = _db.GetUserbyId(id);
            if (user.Password != oldPassword)
            {
                Console.WriteLine("[Error] Old password did not match", ConsoleColor.Red);
                return;
            }
            if (Validation.ValidatePassword(newPassword) == null)
            {
                Console.WriteLine("[Error] New password is not valid", ConsoleColor.Red);
                return;
            }
            user.Password = newPassword;
            _db.UpdateUSer(user);
            Console.WriteLine("Password successfuly changed!", ConsoleColor.Green);
        }
        public void DeactivateAccount(int id)
        {
            _db.RemoveUser(id);
            Console.WriteLine("Processing request...");
            Thread.Sleep(2000);
            Console.WriteLine("Deactivated");
            Console.Clear();
        }
        public T LogIn(string username, string password)
        {
            T user = _db.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);


            if (user == null)
            {
                Console.WriteLine("[Error] Username or password did not match!, Please try Again", ConsoleColor.Red);
                Console.ReadLine();
                Console.Clear();
                return null;
            }
            return user;
        }

        public T Register(T user)
        {
            if (
            
                     Validation.ValidateUsername(user.Username) == null
                    || Validation.ValidatePassword(user.Password) == null)
                {
                    Console.WriteLine("[Error] Invalid info! Try Again!", ConsoleColor.Red);

                    Console.ReadLine();
                Console.Clear();
                    return null;

                }
                int id = _db.Insert(user);
                return _db.GetUserbyId(id);
            }
        

        public void SeeStatistics(User user)
        {
            Console.WriteLine("Your statistics");

            if (user.Activities.Count == 0)
            {
                Console.WriteLine("You dont have any statistics yet");
            }
            foreach(var activity in user.Activities)
            { 
                activity.PrintInfo();
            }
              
        }
    }
}
