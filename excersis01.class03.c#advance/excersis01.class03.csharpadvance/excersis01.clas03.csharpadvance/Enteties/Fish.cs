using System;
using System.Collections.Generic;
using System.Text;

namespace excersis01.clas03.csharpadvance.Enteties
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }

        public override string PrintInfo()
        {
           return $"The fish Named {Name} is {Color} color ,size {Size} and type {Type}";
        }
    }
}
