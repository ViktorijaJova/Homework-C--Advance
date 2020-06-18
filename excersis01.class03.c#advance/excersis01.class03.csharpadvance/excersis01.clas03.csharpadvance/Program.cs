using excersis01.clas03.csharpadvance.Enteties;
using System;

namespace excersis01.clas03.csharpadvance
{
    class Program
    {
        public static PetStore<Dog> DogStore = new PetStore<Dog>();
        public static PetStore<Cat> CatStore = new PetStore<Cat>();
        public static PetStore<Fish> FishStore = new PetStore<Fish>();

        static void Main(string[] args)
        {

            DogStore.AddPetToTheStore(new Dog() {Name="Roki",Age = 1,GoodBoy = true,FavoriteFood = "AllFood",Type = "Yorki"});
            DogStore.AddPetToTheStore(new Dog() { Name = "Lea", Age = 4, GoodBoy = false, FavoriteFood = "Beef", Type = "Retriver" });

            CatStore.AddPetToTheStore(new Cat() { Name = "Garfild", Age = 2, isLazy = true, LifesLeft = 5, Type = "Abyssinian" });
            CatStore.AddPetToTheStore(new Cat() { Name = "Claud", Age = 1, isLazy = false, LifesLeft = 1, Type = "Bengal" });

            FishStore.AddPetToTheStore(new Fish() { Name = "Nemo", Age = 2, Color = "orange", Size = 2, Type = "clownfish" });
            FishStore.AddPetToTheStore(new Fish() { Name = "Dori", Age = 1, Color = "blue", Size = 1, Type = "Paracanthurus hepatus" });

            DogStore.BuyPet("Roki");
            CatStore.BuyPet("idi");

            Console.WriteLine("Dog Store:");
            DogStore.PrintAll();

            Console.WriteLine("Cat Store:");
            CatStore.PrintAll();

            Console.WriteLine("Fish Store:");
            FishStore.PrintAll();


            Console.ReadLine();
        }

    }
}
