using excersise01.csharpadvance.Enteties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace excersise01.csharpadvance
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog() { Id = 1, Name = "Roki", Color = "yellow" };
            Dog dog1 = new Dog() { Id = 0, Name = "Winter", Color = "black" };
            Dog dog2 = new Dog() { Id = 2, Name = "Zigi", Color = "white" };

             dog.Bark();

          if(  dog.Validate(dog.Id,dog.Name,dog.Color) == true)
            {
                DogShelter.Dogs.Add(dog);
            }

         DogShelter.PrintAll(DogShelter.Dogs);
         

            Console.ReadLine();

        }
     
      

        }



    }
