using System;
using System.Collections.Generic;
using System.Text;

namespace excersis01.clas03.csharpadvance.Enteties
{
    public class Cat : Pet
    {
        public bool isLazy { get; set; }
        public int LifesLeft { get; set; }

        public override string PrintInfo()
        {
            return $"The cat named:{Name} has {LifesLeft} lifes left, {Age} age  and type {Type}";
        }
    }
}
