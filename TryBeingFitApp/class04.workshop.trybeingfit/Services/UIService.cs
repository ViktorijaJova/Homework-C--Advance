using class04.workshop.trybeingfit.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using workshop.TryBeingFit.Domain.Enteties;
using workshop.TryBeingFit.Domain.Enums;
using workshop.TryBeingFit.Domain.Interfaces;

namespace class04.workshop.trybeingfit.Services.Services
{
	public class UIService : IUIService
	{
		public List<string> MainMenuItems { get; set; }
		public int MainMenu(UserRole role)
		{
			MainMenuItems = new List<string>() { "Account", "Log Out" };
			switch (role)
			{
				case UserRole.Standard:
					MainMenuItems.Insert(0, "Train");
					MainMenuItems.Insert(0, "Upgrade to Premium");
					break;
				case UserRole.Premium:
					MainMenuItems.Insert(0, "Train");
					break;
				case UserRole.Trainer:
					MainMenuItems.Insert(0, "Reschedule training");
					break;
			}
			return ChooseMenu(MainMenuItems);
		}

		public int AccountMenu(UserRole role)
		{
			List<string> menuItems = new List<string>() { "Change Info", "Check Subscription", "Change Password" };
			if (role != UserRole.Trainer)
			{
				menuItems.Add("Change Trainings");
			}
			return ChooseMenu(menuItems);
		}

		public int ChooseEntiiesMenu<T>(List<T> entities) where T : IBaseEntity
		{
			while (true)
			{
				Console.WriteLine("Enter a number to choose one of the following:");
				for (int i = 0; i < entities.Count; i++)
				{
					Console.WriteLine($"{i + 1}) {entities[i].PrintInfo()}");
				}
				int choice = ValidationHelper.ValidateNumber(Console.ReadLine(), entities.Count);
				if (choice == -1)
				{
					MessageHelper.Color("[Error] Input incorrect. Please try again", ConsoleColor.Red);
					Console.ReadLine();
					continue;
				}
				return choice;
			}
		}

		public int ChooseMenu<T>(List<T> items)
		{
			while (true)
			{
				Console.WriteLine("Enter a number to choose one of the following:");
				for (int i = 0; i < items.Count; i++)
				{
					Console.WriteLine($"{i + 1}) {items[i]}");
				}
				int choice = ValidationHelper.ValidateNumber(Console.ReadLine(), items.Count);
				if (choice == -1)
				{
					MessageHelper.Color("[Error] Input incorrect. Please try again", ConsoleColor.Red);
					Console.ReadLine();
					continue;
				}
				return choice;
			}
		}

		public void Welcome(User user)
		{
			Console.WriteLine($"Welcome to the fitness app {user.UserName}!");
			switch (user.Role)
			{
				case UserRole.Standard:
					Console.WriteLine("If you enjoy the app, consider our Premium subscription!");
					break;
				case UserRole.Premium:
					Console.WriteLine("We are so glad you are part of our community!");
					break;
				case UserRole.Trainer:
					Console.WriteLine("We are so glad to have you as a partner!");
					break;
			}
		}

		public int LogInMenu()
		{
			List<string> menuItems = new List<string>() { "LogIn", "Register" };
			return ChooseMenu(menuItems);
		}

		public int RoleMenu()
		{
			List<string> menuItems = Enum.GetNames(typeof(UserRole)).ToList();
			return ChooseMenu(menuItems);
		}

		public int TrainMenu()
		{
			Console.Clear();
			List<string> trainingMenu = new List<string>() { "Video", "Live" };
			Console.WriteLine("Choose what type pf training do you want");
			return ChooseMenu(trainingMenu);
		}

		public int TrainMenuItems<T>(List<T> trainings) where T : Training
		{
			Console.Clear();
			Console.WriteLine("Choose a training:");
			return ChooseEntiiesMenu(trainings);
		}

		public void UpgradeToPremium()
		{
			Console.Clear();
			Console.WriteLine("Upgrade to premium to get these features:");
			Console.WriteLine("* Live trainings");
			Console.WriteLine("* Newsletter in your mail");
			Console.WriteLine("* Discounts at sposrts equipment stores");
			Console.ReadLine();
		}
	}
}

