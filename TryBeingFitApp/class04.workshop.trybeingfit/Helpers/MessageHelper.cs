using System;
using System.Collections.Generic;
using System.Text;

namespace class04.workshop.trybeingfit.Services.Helpers
{

	public static class MessageHelper
	{
		public static void Color(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
