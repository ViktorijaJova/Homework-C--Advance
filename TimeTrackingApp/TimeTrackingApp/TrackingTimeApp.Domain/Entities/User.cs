using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Interfaces;

namespace TrackingTimeApp.Domain.Entities
{
    public class User : AllActivities,IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User( string firstname, int age, string username, string password)
        {
            FirstName = firstname;
            Age = age;
            Username = username;
            Password = password;
        }

        public User()
        {

        }
    }
}
