using Homework._05.AdvCSharp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework._05.AdvCSharp.Domain.Entities
{
	public class Person :BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public Job Occupation { get; set; }
		public List<Dog> Dogs { get; set; }

		public Person(string firstName, string lastName, int age, Job occupation)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Occupation = occupation;
			Dogs = new List<Dog>();
		}

		public override string Info()
		{
			string result = $" {FirstName} {LastName} - {Age} years old.";
			return result;
		}
	}
}
