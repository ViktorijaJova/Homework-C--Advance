using Homework._05.AdvCSharp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework._05.AdvCSharp.Domain.Entities
{
	public class Dog:BaseEntity
	{
		public string Name { get; set; }
		public string Color { get; set; }
		public int Age { get; set; }
		public Race Race { get; set; }

		public Dog(string name, string color, int age, Race race)
		{
			Name = name;
			Color = color;
			Age = age;
			Race = race;
		}

		public override string Info()
		{
			string result = $" {Name} {Color} - {Age} years old.";
			return result;
		}
	}
}
