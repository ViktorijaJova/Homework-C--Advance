using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace excersis01.clas03.csharpadvance.Enteties
{
    public class PetStore<T> where T:Pet
    {
        private List<T> ListofPets;

        public PetStore()
        {
            ListofPets = new List<T>();
        }

   

        public void PrintAll()
        {
            foreach (T pet in ListofPets)
            {
                Console.WriteLine(pet.PrintInfo());
            }
        }

        public void BuyPet(string name)
        {
            T pet = ListofPets.FirstOrDefault(_pet => _pet.Name == name);
            if (pet == null)
            {
                Console.WriteLine($"Pet with that name {name} was not found");
                return;

            }
            ListofPets.Remove(pet);
            Console.WriteLine($"Congrats you just bought the pet {name}");

        }

        public void AddPetToTheStore(T pet)
        {
            ListofPets.Add(pet);

        }


    }
}
