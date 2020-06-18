using System;
using System.Collections.Generic;
using System.Text;
using Task01.CSharpAdvance.Enteties.Interfaces;

namespace Task01.CSharpAdvance.Enteties
{
    public class Teacher : User, ITeacher
    { 

    public List<string> Subjects{ get; set; }




        public void PrintSubject()
        {
            foreach(var subject in Subjects)
            {
                Console.WriteLine($"{subject}");
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Teacher: {Name} with username {UserName} that teaches {Subjects.Count} subjecs");
        }
    }
}
