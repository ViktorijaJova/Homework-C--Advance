using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace excersise01.csharpadvance.Enteties
{
   public class Dog
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("Bark Bark");
        }

        public bool Validate(int id, string name, string color)
        {
            if (id != 0 && name.Length >=2 && color !=null)
            {
                return true;
            }
            return false;
        }





    }

  
}
