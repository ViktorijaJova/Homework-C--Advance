using Homework._05.AdvCSharp.Domain;
using Homework._05.AdvCSharp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Homework._05.advcSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var getnameswithRandDescAge = DataBase.people
                .FindAll(person => person.FirstName.StartsWith('R'))
                .OrderByDescending(person => person.Age).ToList();
                getnameswithRandDescAge.PrintEntities();


            var brownDogsOlder3 = DataBase.dogs
                .FindAll(dog => dog.Color == "Brown" && dog.Age > 3)
                .OrderBy(dog => dog.Age).ToList();
                 brownDogsOlder3.PrintEntities();


            var person2dogs = DataBase.people
                .FindAll(person => person.Dogs.Count > 2)
                .OrderByDescending(person => person.FirstName).ToList();
                person2dogs.PrintEntities();




            var freddiesDogs = DataBase.people
              .Where(person => person.FirstName == "Freddy")
              .Select(dog => dog.Dogs.Find(dog => dog.Age > 1))
              .OrderBy(dog => dog.Name).ToList();  
               freddiesDogs.PrintEntities();


            var nathansFirstDog = DataBase.people
                .Where(person => person.FirstName == "Nathen")
                .Select(person => person.Dogs.First()).ToList();
                nathansFirstDog.PrintEntities();


            //npt working

            var whiteDogs = DataBase.people
                .FindAll(person => person.Dogs.Count > 1)
               
                .Select(person => person.Dogs.Find(dog => dog.Color == "White")).ToList();
            //whiteDogs.PrintEntities();
                 


          


         


            
          
            
          




            Console.ReadLine();
        }
    }

 
}
