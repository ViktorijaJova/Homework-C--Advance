using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Interfaces;

namespace TrackingTimeApp.Domain.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<BaseEntity> Activities { get; set; } = new List<BaseEntity>();

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
