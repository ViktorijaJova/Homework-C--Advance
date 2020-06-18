using System;
using System.Collections.Generic;
using System.Text;

namespace Homework._05.AdvCSharp.Domain.Entities
{
     public static class Helper
    {

		public static void PrintEntities<T>(this List<T> list) where T : BaseEntity
		{
			Console.WriteLine($"Printing {list[0].GetType().Name}s...");
			Console.WriteLine("------------------------------");
			foreach (T item in list)
			{
				Console.WriteLine(item.Info());
			}
			Console.WriteLine("------------------------------");
		}
	}
}
