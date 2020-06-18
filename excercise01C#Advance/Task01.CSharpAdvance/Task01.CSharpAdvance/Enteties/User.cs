using System;
using System.Collections.Generic;
using System.Text;
using Task01.CSharpAdvance.Enteties.Interfaces;

namespace Task01.CSharpAdvance.Enteties
{
     public abstract class User:IUser
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
         public int Password { get; set; }


        public abstract void PrintUser();
       
    }
}
