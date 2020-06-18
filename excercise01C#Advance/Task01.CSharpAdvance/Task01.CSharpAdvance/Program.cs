using System;
using System.Collections.Generic;
using Task01.CSharpAdvance.Enteties;

namespace Task01.CSharpAdvance
{
    class Program
    {
        static void Main(string[] args)
        {


			Student Viktorija = new Student() {Id = 1,	Name = "Viktorija",UserName = "Viki",	Password = 2222,	Grades = new List<int>() {  9, 9 }	};
			Student Margo = new Student(){Id = 2,	Name = "Margo",	UserName = "Margo111",	Password = 222,	Grades = new List<int>() { 10 }};
			Teacher Will = new Teacher(){	Id = 3,	Name = "Will",	UserName = "Will111",	Password =2222,	Subjects = new List<string>() { "C#", "C++", "C" }	};
			Teacher Kate = new Teacher(){Id = 4,Name = "Kate",UserName = "Kate112",	Password = 5555,Subjects = new List<string>() { "SQL", "Ruby" }	};
		
			
			
		Viktorija.PrintUser();
		Margo.PrintUser();
			Will.PrintUser();
			Kate.PrintUser();

			Console.ReadLine();
        }
    }
}
