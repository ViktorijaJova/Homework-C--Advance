using System;
using System.Runtime.Serialization;
using System.Threading;
using TimeTrackingApp.Services.Helpers;
using TimeTrackingApp.Services.Services;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;

namespace TimeTrackingApp
{


	class Program
	{
		public static ActivityServices<BaseEntity> _activityServices = new ActivityServices<BaseEntity>();
		public static MenuService _menu = new MenuService();
		public static UserService<User> _userService = new UserService<User>();
		public static User _currentuser = new User();


		public static void Users()
		{
			_userService.Register(new User { FirstName = "Viktorija", Age = 23, Username = "Viktorija123", Password = "Viki123" });
			_userService.Register(new User { FirstName = "Monika", Age = 33, Username = "Monika123", Password = "Monika123" });


		}
		public
		static void Main(string[] args)
		{

			Users();

			while (true)
			{
				_menu.Welcome(_currentuser);
				var readline = Console.ReadLine();
				Console.Clear();
				if (readline == "1")
				{
					int userChoice = _menu.LogInMenu();
					Console.Clear();
					if (userChoice == 1)
					{
						Console.WriteLine("Enter  your Username:");
						string username = Console.ReadLine();
						Console.WriteLine("Enter  your Password:");
						string password = Console.ReadLine();

						_currentuser = _userService.LogIn(username, password);
						if (_currentuser == null) continue;


						bool isLoged = true;
						Console.Clear();
				
						while (isLoged)
						{
							int choice = _menu.MainMenu();
							Console.Clear();
							if (choice == 1)
							{
								int choiceactivity = _menu.ActivityMenu();
								ActivityType currentActivity = (ActivityType)choiceactivity;
								_activityServices.Tracking(currentActivity, _currentuser);

							}

							if (choice == 2)
							{
								Console.WriteLine("Account managment, choose what to do:");
								Console.WriteLine("1.Deactivate account 2.Change Password 3.ChangeInfo");
								int readmanagingchoice = int.Parse(Console.ReadLine());
								if(readmanagingchoice == 1)
								{
									Console.WriteLine("Enter your id");
									 var readingid = int.Parse(Console.ReadLine());
									_userService.DeactivateAccount(readingid);
								}
								else if(readmanagingchoice == 2)
								{
									Console.WriteLine("Enter your id");
									var readid = int.Parse(Console.ReadLine());
									Console.WriteLine("Enter your old password:");
								    var oldpassword = Console.ReadLine();
									Console.WriteLine("Enter your new password");
									var newpassword = Console.ReadLine();
									_userService.ChangePassword(readid, oldpassword, newpassword);
								}
								else if(readmanagingchoice == 3)
								{
									Console.WriteLine("Enter your id");
									var readingid = int.Parse(Console.ReadLine());
									Console.WriteLine("Enter your first name:");
									var name = Console.ReadLine();
									Console.WriteLine("Enter your last name:");
									var lastname = Console.ReadLine();
									_userService.ChangeInfo(readingid, name, lastname);
								}
							    
							}
							
							if (choice == 3)
							{
								_userService.SeeStatistics(_currentuser);
								Thread.Sleep(2000);
								Console.Clear();
							}
						
							if (choice == 4)
							{
								isLoged = !isLoged;
							}

						}
					}
					
				}
				else if(readline == "2")
				{
					Console.WriteLine("Enter the following to register");
					Console.WriteLine("First name");
					string firstname = Console.ReadLine();
					Console.WriteLine("Last name:");
					string lastname = Console.ReadLine();
					Console.WriteLine("Age");
					int age = int.Parse(Console.ReadLine());
					Console.WriteLine("Enter username");
					string username = Console.ReadLine();
					Console.WriteLine("Enter pass");
					string pass = Console.ReadLine();

					var user = new User(firstname, age, username, pass);
					_userService.Register(user);
					Console.WriteLine("Successfully regisitered!");

				}
				else
				{
					Environment.Exit(0);
				}
				}
		}

	}
}

