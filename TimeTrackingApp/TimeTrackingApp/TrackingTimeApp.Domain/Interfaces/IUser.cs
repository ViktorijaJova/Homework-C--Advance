using System;
using System.Collections.Generic;
using System.Text;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TrackingTimeApp.Domain.Interfaces
{
    public interface IUser
    {
       public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Password { get; set; }
        List<BaseEntity> Activities { get; set; }


    }
}
