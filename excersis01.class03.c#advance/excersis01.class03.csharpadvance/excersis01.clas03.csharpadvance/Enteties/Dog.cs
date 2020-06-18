using System;
using System.Collections.Generic;
using System.Text;

namespace excersis01.clas03.csharpadvance.Enteties
{
    public class Dog : Pet


    {

        public bool GoodBoy { get; set; }
        public string FavoriteFood { get; set; }

        public override string PrintInfo()
        {
            return $" The Dog Named {Name} Favorite food is {FavoriteFood}, age {Age}, Type {Type}";
        }
    }
}
