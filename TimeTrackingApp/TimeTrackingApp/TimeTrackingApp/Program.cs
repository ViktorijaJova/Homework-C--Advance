using System;
using System.Linq;
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
		public static ActivityServices _activityServices = new ActivityServices();
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
						string password = Validation.ValidatePassword(Console.ReadLine());

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
								Console.WriteLine("1.Deactivate account 2.Change Password 3.ChangeFirstName 4.Change LastName");
								int readmanagingchoice = Validation.ValidateNumber(Console.ReadLine(),4);
								if(readmanagingchoice == 1)
								{
									Console.WriteLine("Enter your id");
									 var readingid = Validation.ValidateNumber(Console.ReadLine(),50);
									_userService.DeactivateAccount(readingid);

								}
								else if(readmanagingchoice == 2)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(),50);
									Console.WriteLine("Enter your old password:");
								    var oldpassword = Validation.ValidatePassword(Console.ReadLine());
									Console.WriteLine("Enter your new password");
									var newpassword = Validation.ValidatePassword(Console.ReadLine());
									_userService.ChangePassword(readid, oldpassword, newpassword);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");

								}
								else if(readmanagingchoice == 3)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(), 50);
									Console.WriteLine("Enter your firstName:");
									var oldfirstname = Validation.ValidateString(Console.ReadLine());
									Console.WriteLine("Enter your new firstName");
									var newfirstname = Validation.ValidateString(Console.ReadLine());
									_userService.ChangeFirstName(readid,newfirstname);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");
									Console.ResetColor();
									Thread.Sleep(2000);
									Console.Clear();


								}
								else if(readmanagingchoice == 4)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(), 50);
									Console.WriteLine("Enter your lastName:");
									var oldlastname = Validation.ValidateString(Console.ReadLine());
									Console.WriteLine("Enter your new lastName");
									var newlastname = Validation.ValidateString(Console.ReadLine());
									_userService.ChangeFirstName(readid, newlastname);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");
									Console.ResetColor();
									Thread.Sleep(2000);
									Console.Clear();

								}
							

							}
							
							if (choice == 3)
							{
								_menu.StatisticMenu();
								int readlineforstatistic = Validation.ValidateNumber(Console.ReadLine(),5);
								if(readlineforstatistic == 1)
								{
									_userService.SeeStatistics(_currentuser);
								}
								else if(readlineforstatistic == 2)
								{
									_userService.SeeStatistics(_currentuser);

								}
								else if(readlineforstatistic == 3)
								{
									_userService.SeeStatistics(_currentuser);

								}
								else if(readlineforstatistic == 4)
								{
									_userService.SeeStatistics(_currentuser);

								}
								else if(readlineforstatistic ==5)
								{
									_userService.GlobalTime(_currentuser);

								}

						/*		Thread.Sleep(5000);
								Console.Clear();*/
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
					int age = Validation.ValidateNumber(Console.ReadLine(),100);
					Console.WriteLine("Enter username");
					string username = Console.ReadLine();
					Console.WriteLine("Enter pass");
					string pass = Validation.ValidatePassword(Console.ReadLine());

					var user = new User(firstname, age, username, pass);
					_userService.Register(user);
					Console.BackgroundColor = ConsoleColor.Green;
					Console.WriteLine("Successfully regisitered!");
					Console.ResetColor();
					Thread.Sleep(2000);
					Console.Clear();
					

				}
				else
				{
					Environment.Exit(0);
				}
				}
		}

	}
}

