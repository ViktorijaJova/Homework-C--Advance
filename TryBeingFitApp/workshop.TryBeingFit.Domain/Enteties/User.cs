using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using workshop.TryBeingFit.Domain.Enums;
using workshop.TryBeingFit.Domain.Interfaces;

namespace workshop.TryBeingFit.Domain.Enteties
{
  public abstract  class User:BaseEntity, IUser
        
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }



    }
}
