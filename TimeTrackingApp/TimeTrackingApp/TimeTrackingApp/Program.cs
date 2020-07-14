using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using TimeTrackingApp.Services.Helpers;
using TimeTrackingApp.Services.Services;
using TrackingTimeApp.Domain;
using TrackingTimeApp.Domain.Entities;
using TrackingTimeApp.Domain.Enums;
using TrackingTimeApp.Domain.Interfaces;

namespace TimeTrackingApp
{


	class Program
	{
		public static ActivityServices _activityServices = new ActivityServices();
		public static MenuService _menu = new MenuService();
		public static UserService<User> _userService = new UserService<User>();
		public static User _currentuser = new User();
		static IDb<User> _userDb = new Db<User>();


		public static void Users()
		{
			_userService.Register(new User {Id=1, FirstName = "Viktorija", Age = 23, Username = "Viktorija123", Password = "Viki123" });
			
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
						Console.BackgroundColor = ConsoleColor.Green;
						Console.WriteLine(" Successful Login Welcome back");
						Console.ResetColor();
						Console.ReadLine();
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
								Console.WriteLine("1.Deactivate account 2.Change Password 3.ChangeFirstName 4.Change LastName 5.GoBack");
								int readmanagingchoice = Validation.ValidateNumber(Console.ReadLine(),5);
								if(readmanagingchoice == 1)
								{
									Console.WriteLine("Enter your id");
									 var readingid = Validation.ValidateNumber(Console.ReadLine(),10);
									_userService.DeactivateAccount(readingid);

								}
								else if(readmanagingchoice == 2)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(),10);
									Console.WriteLine("Enter your old password:");
								    var oldpassword = Validation.ValidatePassword(Console.ReadLine());
									Console.WriteLine("Enter your new password");
									var newpassword = Validation.ValidatePassword(Console.ReadLine());
									_userService.ChangePassword(readid, oldpassword, newpassword);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");
									Console.ResetColor();
									Console.ReadLine();
									Console.Clear();

								}
								else if(readmanagingchoice == 3)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(), 10);
									Console.WriteLine("Enter your firstName:");
									var oldfirstname = Validation.ValidateString(Console.ReadLine());
									Console.WriteLine("Enter your new firstName");
									var newfirstname = Validation.ValidateString(Console.ReadLine());
									_userService.ChangeFirstName(readid,newfirstname);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");
									Console.ResetColor();
									Console.ReadLine();
									Console.Clear();


								}
								else if(readmanagingchoice == 4)
								{
									Console.WriteLine("Enter your id");
									var readid = Validation.ValidateNumber(Console.ReadLine(), 10);
									Console.WriteLine("Enter your lastName:");
									var oldlastname = Validation.ValidateString(Console.ReadLine());
									Console.WriteLine("Enter your new lastName");
									var newlastname = Validation.ValidateString(Console.ReadLine());
									_userService.ChangeFirstName(readid, newlastname);
									Console.BackgroundColor = ConsoleColor.Green;
									Console.WriteLine("Succesful");
									Console.ResetColor();
									Console.ReadLine();
									Console.Clear();

								}
								else if(readmanagingchoice == 5)
								{
									Console.Clear();
									continue;
								}
							

							}
							
							if (choice == 3)
							{
								_menu.StatisticMenu();
								int readlineforstatistic = Validation.ValidateNumber(Console.ReadLine(),6);
								
								switch (readlineforstatistic)
								{
									case 1: 
										_activityServices.SeeReadingStats(_currentuser);
										break;
									case 2: 
										_activityServices.SeePuzzlesStats(_currentuser);

										break;
									case 3: 
									_activityServices.SeeWatchingStats(_currentuser);

										break;
									case 4:
									_activityServices.SeeOtherHobbiesStats(_currentuser);

										break;
									case 5: 
									_activityServices.SeeGeneralStats(_currentuser);

										break;
									case 6:
										Console.Clear();
										break;
								
								}
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
					Console.ReadLine();
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

