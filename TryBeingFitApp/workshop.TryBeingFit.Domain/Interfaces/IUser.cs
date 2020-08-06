using System;
using System.Collections.Generic;
using System.Text;

namespace workshop.TryBeingFit.Domain.Interfaces
{
  public  interface IUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


    }
}
