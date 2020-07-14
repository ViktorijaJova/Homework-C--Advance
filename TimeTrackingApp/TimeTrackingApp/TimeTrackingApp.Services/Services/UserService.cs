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

       
        public void ChangeFirstName(int id, string firstName)
        {
            T user = _db.GetUserById(id);
            if (Validation.ValidateString(firstName) == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error] strings were not valid. Please try again!");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
            user.FirstName = firstName;
            _db.UpdateUser(user);
            Console.WriteLine("Data successfuly changed!", ConsoleColor.Green);
        }
        public void ChangeLastName(int id, string lastName)
        {
            T user = _db.GetUserById(id);
            if ( Validation.ValidateString(lastName) == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error] strings were not valid. Please try again!");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
            user.LastName = lastName;
            _db.UpdateUser(user);
            Console.WriteLine("Data successfuly changed!", ConsoleColor.Green);
        }



        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            var user = _db.GetUserById(id);
            if (user.Password == oldPassword && oldPassword != newPassword)
            {
                if (Validation.ValidatePassword(newPassword) == null)
                {

                    Console.WriteLine("Password should not be shorter than 6 characters", ConsoleColor.Red);
                    Thread.Sleep(3000);
                    return;
                }
            }
            else
            {
                Console.WriteLine("You entered your old password wrong");
                Thread.Sleep(3000);
                return;
            }
            user.Password = newPassword;
            _db.UpdateUser(user);
            Console.WriteLine("You succesfully changed your password!", ConsoleColor.Green);
        }
        public void DeactivateAccount(int id)
        {
            Console.WriteLine("deactivate your account? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                Console.WriteLine("Your account has been deacivated", ConsoleColor.Green);
            }
            else
            {
                return;
            }
        }
        public T LogIn(string username, string password)
        {
            T user = _db.GetAllNewWay().FirstOrDefault(x => x.Username == username && x.Password == password);


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
                int id = _db.InsertNewWay(user);
                return _db.GetById(id);
            }
        

   /*     public void SeeStatistics(User user)
        {
            Console.WriteLine("Your statistics");

            if (user.Activities.Count == 0)
            {
                Console.WriteLine("You dont have any statistics yet");
            }
             
        

              

        }*/


    


    }
}
