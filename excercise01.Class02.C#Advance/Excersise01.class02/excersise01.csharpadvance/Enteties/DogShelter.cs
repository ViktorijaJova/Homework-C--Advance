using System;
using System.Collections.Generic;
using System.Text;

namespace excersise01.csharpadvance.Enteties
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; } = new List<Dog>();
        public static void PrintAll(List<Dog> dogs)
        {
            foreach (var dog in dogs)
            {
                Console.WriteLine($"{dog.Id}, Name: {dog.Name}, Color: {dog.Color}"); 
            }


        }
    }
}
