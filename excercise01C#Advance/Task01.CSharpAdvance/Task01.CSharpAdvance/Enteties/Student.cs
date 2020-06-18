using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task01.CSharpAdvance.Enteties.Interfaces;

namespace Task01.CSharpAdvance.Enteties
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public void PrintGrade()
        {
            foreach(var grade in Grades)
            {
                Console.WriteLine($"{grade}");
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Student: {Name} with username {UserName} and average grade of {Grades.Sum() / Grades.Count}");
        }
    }
}
